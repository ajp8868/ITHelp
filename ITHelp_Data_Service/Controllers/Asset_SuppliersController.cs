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
    public class Asset_SuppliersController : ApiController
    {
        private Entities db = new Entities();

        // GET: api/Asset_Suppliers
        public IQueryable<Asset_Suppliers> GetAsset_Suppliers()
        {
            return db.Asset_Suppliers;
        }

        // GET: api/Asset_Suppliers/5
        [ResponseType(typeof(Asset_Suppliers))]
        public IHttpActionResult GetAsset_Suppliers(int id)
        {
            Asset_Suppliers asset_Suppliers = db.Asset_Suppliers.Find(id);
            if (asset_Suppliers == null)
            {
                return NotFound();
            }

            return Ok(asset_Suppliers);
        }

        // PUT: api/Asset_Suppliers/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutAsset_Suppliers(int id, Asset_Suppliers asset_Suppliers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != asset_Suppliers.Id)
            {
                return BadRequest();
            }

            db.Entry(asset_Suppliers).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Asset_SuppliersExists(id))
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

        // POST: api/Asset_Suppliers
        [ResponseType(typeof(Asset_Suppliers))]
        public IHttpActionResult PostAsset_Suppliers(Asset_Suppliers asset_Suppliers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Asset_Suppliers.Add(asset_Suppliers);

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (Asset_SuppliersExists(asset_Suppliers.Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtRoute("DefaultApi", new { id = asset_Suppliers.Id }, asset_Suppliers);
        }

        // DELETE: api/Asset_Suppliers/5
        [ResponseType(typeof(Asset_Suppliers))]
        public IHttpActionResult DeleteAsset_Suppliers(int id)
        {
            Asset_Suppliers asset_Suppliers = db.Asset_Suppliers.Find(id);
            if (asset_Suppliers == null)
            {
                return NotFound();
            }

            db.Asset_Suppliers.Remove(asset_Suppliers);
            db.SaveChanges();

            return Ok(asset_Suppliers);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Asset_SuppliersExists(int id)
        {
            return db.Asset_Suppliers.Count(e => e.Id == id) > 0;
        }
    }
}