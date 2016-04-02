using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using ITHelp_Models;

namespace ITHelp_Site.Controllers
{
    public class TicketsController : Controller
    {
        private ServiceConnector sc = new ServiceConnector();

        // GET: Tickets
        public ActionResult Index()
        {
            return View(sc.GetTicketsAsync());
        }

        // GET: Tickets/Details/5
        public async Task<ActionResult> Details(int? id)
        {
            return null;
        }

        // GET: Tickets/Create
        public ActionResult Create()
        {
            return View();
        }

        //// POST: Tickets/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Create([Bind(Include = "Id,Reference,Title,Description,Raised,Status_Id,Completed_On,Urgency_Id,Type_Id,Raised_By,Needs_Approval,Approved_By,Required_By")] Ticket ticket)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Tickets.Add(ticket);
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }

        //    return View(ticket);
        //}

        //// GET: Tickets/Edit/5
        //public async Task<ActionResult> Edit(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Ticket ticket = await db.Tickets.FindAsync(id);
        //    if (ticket == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(ticket);
        //}

        //// POST: Tickets/Edit/5
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> Edit([Bind(Include = "Id,Reference,Title,Description,Raised,Status_Id,Completed_On,Urgency_Id,Type_Id,Raised_By,Needs_Approval,Approved_By,Required_By")] Ticket ticket)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.Entry(ticket).State = EntityState.Modified;
        //        await db.SaveChangesAsync();
        //        return RedirectToAction("Index");
        //    }
        //    return View(ticket);
        //}

        //// GET: Tickets/Delete/5
        //public async Task<ActionResult> Delete(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    Ticket ticket = await db.Tickets.FindAsync(id);
        //    if (ticket == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(ticket);
        //}

        //// POST: Tickets/Delete/5
        //[HttpPost, ActionName("Delete")]
        //[ValidateAntiForgeryToken]
        //public async Task<ActionResult> DeleteConfirmed(int id)
        //{
        //    Ticket ticket = await db.Tickets.FindAsync(id);
        //    db.Tickets.Remove(ticket);
        //    await db.SaveChangesAsync();
        //    return RedirectToAction("Index");
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}
    }
}
