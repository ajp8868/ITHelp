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
 * Auto generated ticket type controller.
 * @author Adam Postgate - M2095821
 * Email: ajp8868@aol.com
 */
namespace ITHelp_Data_Service.Controllers
{
    public class Ticket_TypesController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/Ticket_Types
        public IQueryable<Ticket_Types> GetTicket_Types()
        {
            return db.Ticket_Types;
        }

        // GET: api/Ticket_Types/5
        [ResponseType(typeof(Ticket_Types))]
        public IHttpActionResult GetTicket_Types(int id)
        {
            Ticket_Types ticket_Types = db.Ticket_Types.Find(id);
            if (ticket_Types == null)
            {
                return NotFound();
            }

            return Ok(ticket_Types);
        }

        // PUT: api/Ticket_Types/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutTicket_Types(int id, Ticket_Types ticket_Types)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != ticket_Types.Id)
            {
                return BadRequest();
            }

            db.Entry(ticket_Types).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Ticket_TypesExists(id))
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

        // POST: api/Ticket_Types
        [ResponseType(typeof(Ticket_Types))]
        public IHttpActionResult PostTicket_Types(Ticket_Types ticket_Types)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Ticket_Types.Add(ticket_Types);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Ticket_TypesExists(ticket_Types.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = ticket_Types.Id }, ticket_Types);
        }

        // DELETE: api/Ticket_Types/5
        [ResponseType(typeof(Ticket_Types))]
        public IHttpActionResult DeleteTicket_Types(int id)
        {
            Ticket_Types ticket_Types = db.Ticket_Types.Find(id);
            if (ticket_Types == null)
            {
                return NotFound();
            }

            db.Ticket_Types.Remove(ticket_Types);
            db.SaveChanges();

            return Ok(ticket_Types);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Ticket_TypesExists(int id)
        {
            return db.Ticket_Types.Count(e => e.Id == id) > 0;
        }
    }
}