using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using CRUDITHealth.Models;

namespace CRUDITHealth.Controllers
{
    public class pacientesController : ApiController
    {
        private ITHealthEntities1 db = new ITHealthEntities1();

        // GET: api/pacientes
        public IQueryable<paciente> Getpacientes()
        {
            return db.pacientes;
        }

        // GET: api/pacientes/5
        [ResponseType(typeof(paciente))]
        public IHttpActionResult Getpaciente(int id)
        {
            paciente paciente = db.pacientes.Find(id);
            if (paciente == null)
            {
                return NotFound();
            }

            return Ok(paciente);
        }

        // PUT: api/pacientes/5
        [ResponseType(typeof(void))]
        public IHttpActionResult Putpaciente(int id, paciente paciente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != paciente.id)
            {
                return BadRequest();
            }

            db.Entry(paciente).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!pacienteExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/pacientes
        [ResponseType(typeof(paciente))]
        public IHttpActionResult Postpaciente(paciente paciente)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.pacientes.Add(paciente);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = paciente.id }, paciente);
        }

        // DELETE: api/pacientes/5
        [ResponseType(typeof(paciente))]
        public IHttpActionResult Deletepaciente(int id)
        {
            paciente paciente = db.pacientes.Find(id);
            if (paciente == null)
            {
                return NotFound();
            }

            db.pacientes.Remove(paciente);
            db.SaveChanges();

            return Ok(paciente);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool pacienteExists(int id)
        {
            return db.pacientes.Count(e => e.id == id) > 0;
        }
    }
}