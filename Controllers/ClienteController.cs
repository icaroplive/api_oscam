using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
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
        private Servidor servidor;
        protected ClaimsIdentity ClaimsIdentity => User.Identity as ClaimsIdentity;
        protected Guid UserId => new Guid(ClaimsIdentity.FindFirst(ClaimTypes.NameIdentifier)?.Value.ToString());
        public ClienteController(BancoContext db)
        {
            this.db = db;
            this.servidor = db.Servidor.FirstOrDefault();
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
            var smtp = db.Smtp.SingleOrDefault(x => x.id == revendedor.idSmtp);
            
            if (revendedor == null)
            {
                transaction.Rollback();
                return StatusCode(404, Json(new { error = "Você nao possui perfil de revendedor, contate o Administrador" }));
            }
            //inicio financeiro

            Financeiro financeiro = new Financeiro();
            financeiro.idCliente = value.id;
            financeiro.idUser = UserId;
            financeiro.valorCobrado = value.teste ? 0 : value.valorCobrado;
            financeiro.dataLancamento = DateTime.Now;
            financeiro.dataVencimento = value.teste ? DateTime.Now.AddDays(1) : Convert.ToDateTime(string.Format("{0}-{1}-{2}", DateTime.Now.Year, DateTime.Now.AddMonths(DateTime.Now.Date.Day >= revendedor.diaVencimento ? 1 : 0).Month, revendedor.diaVencimento));

            var xp = Math.Round((Convert.ToDateTime(financeiro.dataVencimento).Date - DateTime.Now).TotalDays);

            financeiro.valorLogin = value.teste ? 0 : Decimal.Round((revendedor.valorLogin / 30) * Convert.ToDecimal(xp), 2, MidpointRounding.AwayFromZero);
            db.Financeiro.Add(financeiro);
            db.SaveChanges();

            int result = Oscam.criarUsuarioAsync(value.login, value.senha, value.nome,servidor, Convert.ToInt16(value.ativo)).Result;
            if (result != 200)
            {
                transaction.Rollback();
                return StatusCode(404, Json(new { error = "Falha ao comunicar com servidor CAM, contate o Administrador" }));
            };

            transaction.Commit();
            if (smtp != null) {
                var modeloemail = db.ModeloEmail.SingleOrDefault(x => x.tipo == (financeiro.valorLogin == 0 ? "ContaTeste" : "ContaAtiva"));
                if (modeloemail != null) {
                  var tmp =  SendMail.Send(new ConfEmailViewModel { 
                        ModeloEmail = modeloemail,
                        revendedor = revendedor,
                        smtp = smtp,
                        cliente = value,
                        Financeiro = financeiro,
                        servidor = servidor
                    });
                    if (tmp.sucesso == false) {
                        db.LogEventos.Add(new LogEventos { idUser= UserId, data = DateTime.Now, log = tmp.retorno});
                        db.SaveChanges();
                        
                    }
                }
            }

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
            if (id != null && (!cliente.teste && value.teste))
            {
                return StatusCode(404, Json(new { error = "Uma conta ativa não pode ser transformada em teste" }));
            }
            //se o cliente for teste e passar a ser cliente ativo, gera cobrança

            if (cliente.idUser != UserId)
            {
                return StatusCode(404, Json(new { error = "Você não tem permissão para alterar esse registro" }));
            }
            if (cliente.login != value.login)
            {
                return StatusCode(404, Json(new { error = "Login não pode ser alterado" }));
            }
            var revendedor = db.Revendedor.SingleOrDefault(x => x.idUser == UserId);
            var data = value.teste ? DateTime.Now.AddDays(1) : Convert.ToDateTime(string.Format("{0}-{1}-{2}", DateTime.Now.Year, DateTime.Now.AddMonths(DateTime.Now.Date.Day >= revendedor.diaVencimento ? 1 : 0).Month, revendedor.diaVencimento));
            Financeiro financeiro = new Financeiro();
            financeiro.idCliente = value.id;
            financeiro.idUser = UserId;
            financeiro.valorCobrado = value.teste ? 0 : value.valorCobrado;
            financeiro.dataLancamento = DateTime.Now;
            financeiro.dataVencimento = data;

            var xp = Math.Round((Convert.ToDateTime(financeiro.dataVencimento).Date - DateTime.Now).TotalDays);

            financeiro.valorLogin = value.teste ? 0 : Decimal.Round((revendedor.valorLogin / 30) * Convert.ToDecimal(xp), 2, MidpointRounding.AwayFromZero);
            if (cliente.teste && !value.teste)
            {

                if (revendedor == null)
                {
                    return StatusCode(404, Json(new { error = "Você nao possui perfil de revendedor, contate o Administrador" }));
                }



                var check = db.Financeiro.Where(x => x.valorLogin == 0 && x.valorCobrado == 0 && x.idCliente == value.id).FirstOrDefault();
                //verifica se ja tem cobrança para o mês
                //se não tiver vai adicionar, caso ja tenha, vai atualizar
                if (check == null)
                {
                    db.Financeiro.Add(financeiro);
                }
                else
                {
                    financeiro.Id = check.Id;
                    db.Entry(check).State = EntityState.Detached;
                    db.Financeiro.Update(financeiro);
                }
                db.SaveChanges();
            }
            if (cliente.ativo == true && value.ativo == false)
            {
                var check = db.Financeiro.Where(x => (x.dataVencimento.Month == data.Month) && ( x.dataVencimento.Year == data.Year) && (x.dataVencimento.Year == DateTime.Now.Year) && x.idCliente == value.id).FirstOrDefault();
                if (check == null)
                {
                    db.Financeiro.Add(financeiro);
                    db.SaveChanges();
                }
            }
            int result = Oscam.criarUsuarioAsync(value.login, value.senha, value.nome, servidor,Convert.ToInt16(value.ativo)).Result;
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
                int result = Oscam.deleteAsync(reg.login,servidor).Result;
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
