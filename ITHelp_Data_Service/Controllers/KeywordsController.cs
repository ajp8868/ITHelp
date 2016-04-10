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
 * Auto generated keywords controller.
 * @author Adam Postgate - M2095821
 * Email: ajp8868@aol.com
 */
namespace ITHelp_Data_Service.Controllers
{
    public class KeywordsController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/Keywords
        public IQueryable<Keyword> GetKeywords()
        {
            return db.Keywords;
        }

        // GET: api/Keywords/5
        [ResponseType(typeof(Keyword))]
        public IHttpActionResult GetKeyword(int id)
        {
            Keyword keyword = db.Keywords.Find(id);
            if (keyword == null)
            {
                return NotFound();
            }

            return Ok(keyword);
        }

        // PUT: api/Keywords/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutKeyword(int id, Keyword keyword)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != keyword.Id)
            {
                return BadRequest();
            }

            db.Entry(keyword).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KeywordExists(id))
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

        // POST: api/Keywords
        [ResponseType(typeof(Keyword))]
        public IHttpActionResult PostKeyword(Keyword keyword)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Keywords.Add(keyword);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (KeywordExists(keyword.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = keyword.Id }, keyword);
        }

        // DELETE: api/Keywords/5
        [ResponseType(typeof(Keyword))]
        public IHttpActionResult DeleteKeyword(int id)
        {
            Keyword keyword = db.Keywords.Find(id);
            if (keyword == null)
            {
                return NotFound();
            }

            db.Keywords.Remove(keyword);
            db.SaveChanges();

            return Ok(keyword);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool KeywordExists(int id)
        {
            return db.Keywords.Count(e => e.Id == id) > 0;
        }
    }
}