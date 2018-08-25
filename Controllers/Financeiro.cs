using System;
using System.Collections.Generic;
using System.Linq;
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
    [Route("api/Financeiro")]
    public class FinanceiroController : Controller
    {
        private BancoContext db;
        protected ClaimsIdentity ClaimsIdentity => User.Identity as ClaimsIdentity;
        protected Guid UserId => new Guid(ClaimsIdentity.FindFirst(ClaimTypes.NameIdentifier)?.Value.ToString());
        public FinanceiroController(BancoContext db)
        {
            this.db = db;
        }
        // GET: api/Financeiro
        [HttpGet]
        public IQueryable<Financeiro> Get()
        {
            return db.Financeiro;
        }

        // GET: api/Financeiro/5
        [HttpGet("{id}", Name = "GetFinanceiro")]
        public IActionResult Get(Guid id)
        {
            Financeiro Financeiro = db.Financeiro.Find(id);
            if (Financeiro == null || Financeiro.idUser != UserId)
            {
                return StatusCode(404, Json(new { error = "Registro indisponível" }));
            }

            return Json(Financeiro);
        }

        // POST: api/Financeiro
        [HttpPost]
        public IActionResult Post([FromBody]Financeiro value)
        {
            value.idCliente=new Guid("08d60835-4f28-a5a4-c4e7-c11eff7909ea");
            var revendedor = db.Revendedor.FirstOrDefault(x => x.idUser == UserId);
            value.idUser = UserId;
            value.valorLogin = revendedor.valorLogin;
            value.dataLancamento = DateTime.Now;
            db.Financeiro.Add(value);
            db.SaveChanges();
            return Json(value);
        }

        [HttpPut("{id}")]
        public IActionResult Put(Guid Id, [FromBody] Financeiro value)
        {
            var financeiro = db.Financeiro.SingleOrDefault(x => x.Id == Id);
            value.idUser = UserId;
            value.Id = Id;

            if (financeiro == null)
            {
                return StatusCode(404, Json(new { error = "Registro inexistente" }));
            }
            if (financeiro.idUser != UserId)
            {
                return StatusCode(404, Json(new { error = "Você não tem permissão para alterar esse registro" }));
            }
            db.Entry(financeiro).State = EntityState.Detached;
            db.Financeiro.Update(value);
            db.SaveChanges();
            return Json(value);
        }
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var reg = db.Financeiro.SingleOrDefault(x => x.Id == id);
            if (reg.idUser != UserId)
            {
                return StatusCode(404, Json(new { error = "Você não tem permissão para remover este registro" }));
            }
            if (reg != null)
            {
                db.Entry(reg).State = EntityState.Deleted;
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
