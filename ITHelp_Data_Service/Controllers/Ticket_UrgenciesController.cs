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
using ITHelp_Data_Service.Models;

namespace ITHelp_Data_Service.Controllers
{
    public class Ticket_UrgenciesController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/Ticket_Urgencies
        public IQueryable<Ticket_Urgencies> GetTicket_Urgencies()
        {
            return db.Ticket_Urgencies;
        }

        // GET: api/Ticket_Urgencies/5
        [ResponseType(typeof(Ticket_Urgencies))]
        public IHttpActionResult GetTicket_Urgencies(int id)
        {
            Ticket_Urgencies ticket_Urgencies = db.Ticket_Urgencies.Find(id);
            if (ticket_Urgencies == null)
            {
                return NotFound();
            }

            return Ok(ticket_Urgencies);
        }

        // PUT: api/Ticket_Urgencies/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTicket_Urgencies(int id, Ticket_Urgencies ticket_Urgencies)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ticket_Urgencies.Id)
            {
                return BadRequest();
            }

            db.Entry(ticket_Urgencies).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Ticket_UrgenciesExists(id))
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

        // POST: api/Ticket_Urgencies
        [ResponseType(typeof(Ticket_Urgencies))]
        public IHttpActionResult PostTicket_Urgencies(Ticket_Urgencies ticket_Urgencies)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Ticket_Urgencies.Add(ticket_Urgencies);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Ticket_UrgenciesExists(ticket_Urgencies.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ticket_Urgencies.Id }, ticket_Urgencies);
        }

        // DELETE: api/Ticket_Urgencies/5
        [ResponseType(typeof(Ticket_Urgencies))]
        public IHttpActionResult DeleteTicket_Urgencies(int id)
        {
            Ticket_Urgencies ticket_Urgencies = db.Ticket_Urgencies.Find(id);
            if (ticket_Urgencies == null)
            {
                return NotFound();
            }

            db.Ticket_Urgencies.Remove(ticket_Urgencies);
            db.SaveChanges();

            return Ok(ticket_Urgencies);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Ticket_UrgenciesExists(int id)
        {
            return db.Ticket_Urgencies.Count(e => e.Id == id) > 0;
        }
    }
}