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
    public class KnowledgesController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/Knowledges
        public IQueryable<Knowledge> GetKnowledges()
        {
            return db.Knowledges;
        }

        // GET: api/Knowledges/5
        [ResponseType(typeof(Knowledge))]
        public IHttpActionResult GetKnowledge(int id)
        {
            Knowledge knowledge = db.Knowledges.Find(id);
            if (knowledge == null)
            {
                return NotFound();
            }

            return Ok(knowledge);
        }

        // PUT: api/Knowledges/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKnowledge(int id, Knowledge knowledge)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != knowledge.Id)
            {
                return BadRequest();
            }

            db.Entry(knowledge).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KnowledgeExists(id))
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

        // POST: api/Knowledges
        [ResponseType(typeof(Knowledge))]
        public IHttpActionResult PostKnowledge(Knowledge knowledge)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Knowledges.Add(knowledge);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (KnowledgeExists(knowledge.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = knowledge.Id }, knowledge);
        }

        // DELETE: api/Knowledges/5
        [ResponseType(typeof(Knowledge))]
        public IHttpActionResult DeleteKnowledge(int id)
        {
            Knowledge knowledge = db.Knowledges.Find(id);
            if (knowledge == null)
            {
                return NotFound();
            }

            db.Knowledges.Remove(knowledge);
            db.SaveChanges();

            return Ok(knowledge);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KnowledgeExists(int id)
        {
            return db.Knowledges.Count(e => e.Id == id) > 0;
        }
    }
}