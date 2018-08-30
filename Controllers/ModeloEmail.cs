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
    [Route("api/ModeloEmail")]
    public class ModeloEmailController : Controller
    {

        private BancoContext db;
        public ModeloEmailController(BancoContext db)
        {
            this.db = db;
        }
        // GET: api/ModeloEmail
        [HttpGet]
        public IQueryable<ModeloEmail> Get()
        {
            return db.ModeloEmail;
        }

        // POST: api/ModeloEmail
        [HttpPost]
        public IActionResult Post([FromBody]ModeloEmail value)
        {
            db.ModeloEmail.Add(value);
            db.SaveChanges();
            return Json(value);
        }

        // PUT: api/ModeloEmail/5
        [HttpPut("{id}")]
        public IActionResult Put(Guid id, [FromBody] ModeloEmail value)
        {
            var ModeloEmail = db.ModeloEmail.SingleOrDefault(x => x.id == id);
            value.id = id;

            if (ModeloEmail == null)
            {
                return StatusCode(404, Json(new { error = "Registro inexistente" }));
            }
            db.Entry(ModeloEmail).State = EntityState.Detached;
            db.ModeloEmail.Update(value);
            db.SaveChanges();
            return Json(value);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            var reg = db.ModeloEmail.SingleOrDefault(x => x.id == id);
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
