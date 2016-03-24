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
    public class Ticket_HistoryController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/Ticket_History
        public IQueryable<Ticket_History> GetTicket_History()
        {
            return db.Ticket_History;
        }

        // GET: api/Ticket_History/5
        [ResponseType(typeof(Ticket_History))]
        public IHttpActionResult GetTicket_History(int id)
        {
            Ticket_History ticket_History = db.Ticket_History.Find(id);
            if (ticket_History == null)
            {
                return NotFound();
            }

            return Ok(ticket_History);
        }

        // PUT: api/Ticket_History/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTicket_History(int id, Ticket_History ticket_History)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ticket_History.Id)
            {
                return BadRequest();
            }

            db.Entry(ticket_History).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Ticket_HistoryExists(id))
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

        // POST: api/Ticket_History
        [ResponseType(typeof(Ticket_History))]
        public IHttpActionResult PostTicket_History(Ticket_History ticket_History)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Ticket_History.Add(ticket_History);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Ticket_HistoryExists(ticket_History.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ticket_History.Id }, ticket_History);
        }

        // DELETE: api/Ticket_History/5
        [ResponseType(typeof(Ticket_History))]
        public IHttpActionResult DeleteTicket_History(int id)
        {
            Ticket_History ticket_History = db.Ticket_History.Find(id);
            if (ticket_History == null)
            {
                return NotFound();
            }

            db.Ticket_History.Remove(ticket_History);
            db.SaveChanges();

            return Ok(ticket_History);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Ticket_HistoryExists(int id)
        {
            return db.Ticket_History.Count(e => e.Id == id) > 0;
        }
    }
}