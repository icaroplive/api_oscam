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
    [Produces("application/json")]
    [Route("api/Parametros")]
    public class ParametrosController : Controller
    {

        private BancoContext db;
        protected ClaimsIdentity ClaimsIdentity => User.Identity as ClaimsIdentity;
        protected Guid UserId => new Guid(ClaimsIdentity.FindFirst(ClaimTypes.NameIdentifier)?.Value.ToString());
        public ParametrosController(BancoContext db)
        {
            this.db = db;
        }
        // GET: api/Parametros
        [HttpGet]
        public IActionResult Get()
        {
            SmtpResponse response = SendMail.Send();
            return Json(db.Revendedor.FirstOrDefault(c => c.idUser == UserId));
        }

        // POST: api/Parametros
        [HttpPost]
        public IActionResult Post([FromBody]Revendedor value)
        {
            db.Revendedor.Add(value);
            db.SaveChanges();
            return Json(value);
        }

        // PUT: api/Parametros/5
        [HttpPut]
        public IActionResult Put([FromBody] Revendedor value)
        {
            var Parametros = db.Revendedor.SingleOrDefault(x => x.idUser == UserId);
            if (Parametros != null)
            {
                db.Entry(Parametros).State = EntityState.Detached;
                db.Revendedor.Update(value);
            }
            else
            {
                value.idUser = UserId;
                db.Revendedor.Add(value);
            }
            db.SaveChanges();
            return Json(value);
        }


    }
}
