using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using webapi.Entities;
using webapi.Models;

namespace webapi
{
    [Authorize]
    [Produces("application/json")]
    [Route("api/Cliente")]
    public class ClienteController : Controller
    {
        private BancoContext db;
        protected ClaimsIdentity ClaimsIdentity => User.Identity as ClaimsIdentity;
        protected Guid UserId => new Guid(ClaimsIdentity.FindFirst(ClaimTypes.NameIdentifier)?.Value.ToString());
        public ClienteController(BancoContext db)
        {
            this.db = db;
        }
        // GET: api/Cliente
        [HttpGet]
        public IQueryable<Cliente> Get()
        {
            return db.Cliente.Where(c => c.apagado == false && c.idUser == UserId);
        }

        // GET: api/Cliente/5
        [HttpGet("{id}", Name = "Get")]
        public IActionResult Get(Guid id)
        {
            Cliente cliente = db.Cliente.Find(id);
            if (cliente == null || cliente.idUser != UserId)
            {
                return StatusCode(404, Json(new { error = "Registro indisponível" }));
            }

            return Json(cliente);
        }

        // POST: api/Cliente
        [HttpPost]
        public IActionResult Post([FromBody]Cliente value)
        {
            var transaction = db.Database.BeginTransaction();
            value.idUser = UserId;
            var reg = db.Cliente.SingleOrDefault(x => x.login == value.login);

            if (reg != null)
            {
                return StatusCode(404, Json(new { error = "Login indisponível" }));
            }

            value.dataCriado = DateTime.Now;
            db.Cliente.Add(value);
            db.SaveChanges();

            var revendedor = db.Revendedor.SingleOrDefault(x => x.idUser == UserId);
            if (revendedor == null)
            {
                transaction.Rollback();
                return StatusCode(404, Json(new { error = "Você nao possui perfil de revendedor, contate o Administrador" }));
            }
            //inicio financeiro
            Financeiro financeiro = new Financeiro();
            financeiro.idCliente = value.id;
            financeiro.idUser = UserId;
            financeiro.valorLogin = revendedor.valorLogin;
            financeiro.valorCobrado = value.valorCobrado;
            financeiro.dataLancamento = DateTime.Now;
            financeiro.dataVencimento = Convert.ToDateTime(string.Format("{0}-{1}-{2}", DateTime.Now.Year, DateTime.Now.AddMonths(DateTime.Now.Date.Day >= revendedor.diaVencimento ? 1 : 0).Month, revendedor.diaVencimento));

            var xp = Math.Round((Convert.ToDateTime(financeiro.dataVencimento).Date - DateTime.Now).TotalDays);

            financeiro.valorLogin = Decimal.Round((revendedor.valorLogin / 30) * Convert.ToDecimal(xp), 2, MidpointRounding.AwayFromZero);
            db.Financeiro.Add(financeiro);
            db.SaveChanges();

            int result = Oscam.criarUsuarioAsync(value.login, value.senha, value.nome, Convert.ToInt16(value.ativo)).Result;
            if (result != 200)
            {
                transaction.Rollback();
                return StatusCode(404, Json(new { error = "Falha ao comunicar com servidor CAM, contate o Administrador" }));
            };

            transaction.Commit();
            //fim financeiro
            return Json(value);
        }

        // PUT: api/Cliente/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Cliente value)
        {
            var cliente = db.Cliente.SingleOrDefault(x => x.id == id);
            value.idUser = UserId;
            value.id = id;
            if (cliente == null)
            {
                return StatusCode(404, Json(new { error = "Registro inexistente" }));
            }
            if (cliente.idUser != UserId)
            {
                return StatusCode(404, Json(new { error = "Você não tem permissão para alterar esse registro" }));
            }
            if (cliente.login != value.login)
            {
                return StatusCode(404, Json(new { error = "Login não pode ser alterado" }));
            }
            int result = Oscam.criarUsuarioAsync(value.login, value.senha, value.nome, Convert.ToInt16(value.ativo)).Result;
            if (result != 200)
            {
                return StatusCode(404, Json(new { error = "Falha ao comunicar com servidor CAM, contate o Administrador" }));
            };

            db.Entry(cliente).State = EntityState.Detached;
            db.Cliente.Update(value);
            db.SaveChanges();
            return Json(value);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var reg = db.Cliente.SingleOrDefault(x => x.id == id);
            if (reg.idUser != UserId)
            {
                return StatusCode(404, Json(new { error = "Você não tem permissão para remover este registro" }));
            }
            if (reg != null)
            {
                int result = Oscam.deleteAsync(reg.login).Result;
                if (result != 200)
                {
                    return StatusCode(404, Json(new { error = "Falha ao comunicar com servidor CAM, contate o Administrador" }));
                };
                // db.Cliente.Remove(reg);
                reg.ativo = false;
                reg.apagado = true;
                reg.dataApagado = DateTime.Now;
                db.Entry(reg).State = EntityState.Detached;
                db.Cliente.Update(reg);
                db.SaveChanges();
                return Json(Ok());
            }
            else
            {
                return StatusCode(404, Json(new { error = "Registro inexistente" }));
            }
        }
    }
}
