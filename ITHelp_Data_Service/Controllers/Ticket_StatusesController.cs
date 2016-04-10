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

/*
 * Auto generated ticket status controller
 * @author Adam Postgate - M2095821
 * Email: ajp8868@aol.com
 */
namespace ITHelp_Data_Service.Controllers
{
    public class Ticket_StatusesController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/Ticket_Statuses
        public IQueryable<Ticket_Statuses> GetTicket_Statuses()
        {
            return db.Ticket_Statuses;
        }

        // GET: api/Ticket_Statuses/5
        [ResponseType(typeof(Ticket_Statuses))]
        public IHttpActionResult GetTicket_Statuses(int id)
        {
            Ticket_Statuses ticket_Statuses = db.Ticket_Statuses.Find(id);
            if (ticket_Statuses == null)
            {
                return NotFound();
            }

            return Ok(ticket_Statuses);
        }

        // PUT: api/Ticket_Statuses/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTicket_Statuses(int id, Ticket_Statuses ticket_Statuses)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ticket_Statuses.Id)
            {
                return BadRequest();
            }

            db.Entry(ticket_Statuses).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Ticket_StatusesExists(id))
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

        // POST: api/Ticket_Statuses
        [ResponseType(typeof(Ticket_Statuses))]
        public IHttpActionResult PostTicket_Statuses(Ticket_Statuses ticket_Statuses)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Ticket_Statuses.Add(ticket_Statuses);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Ticket_StatusesExists(ticket_Statuses.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ticket_Statuses.Id }, ticket_Statuses);
        }

        // DELETE: api/Ticket_Statuses/5
        [ResponseType(typeof(Ticket_Statuses))]
        public IHttpActionResult DeleteTicket_Statuses(int id)
        {
            Ticket_Statuses ticket_Statuses = db.Ticket_Statuses.Find(id);
            if (ticket_Statuses == null)
            {
                return NotFound();
            }

            db.Ticket_Statuses.Remove(ticket_Statuses);
            db.SaveChanges();

            return Ok(ticket_Statuses);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Ticket_StatusesExists(int id)
        {
            return db.Ticket_Statuses.Count(e => e.Id == id) > 0;
        }
    }
}