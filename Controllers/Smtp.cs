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
    [Route("api/Smtp")]
    public class SmtpController : Controller
    {

        private BancoContext db;
        public SmtpController(BancoContext db)
        {
            this.db = db;
        }
        // GET: api/Smtp
        [HttpGet]
        public IQueryable<Smtp> Get()
        {
            return db.Smtp;
        }

        // POST: api/Smtp
        [HttpPost]
        public IActionResult Post([FromBody]Smtp value)
        {
            db.Smtp.Add(value);
            db.SaveChanges();
            return Json(value);
        }

        // PUT: api/Smtp/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] Smtp value)
        {
            var Smtp = db.Smtp.SingleOrDefault(x => x.id == id);
            value.id = id;

            if (Smtp == null)
            {
                return StatusCode(404, Json(new { error = "Registro inexistente" }));
            }
            db.Entry(Smtp).State = EntityState.Detached;
            db.Smtp.Update(value);
            db.SaveChanges();
            return Json(value);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var reg = db.Smtp.SingleOrDefault(x => x.id == id);
            if (reg == null)
            {
                return StatusCode(404, Json(new { error = "Registro inexistente" }));
            }
            db.Entry(reg).State = EntityState.Deleted;
            db.SaveChanges();
            return Json(Ok());


        }
    }
}
