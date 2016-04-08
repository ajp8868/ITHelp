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
using WebMatrix.WebData;
using System.Net.Http;

namespace ITHelp_Site.Controllers
{
    [RoutePrefix("public")]
    public class PublicController : Controller
    {
        private UsersContext db = new UsersContext();
        ServiceConnector sc = new ServiceConnector();

        // GET: Public
        public ActionResult Index()
        {
            return View();
        }

        // GET: Tickets
        [Route("tickets")]
        public ActionResult Tickets()
        {
            return View(sc.GetTicketsByUser(WebSecurity.CurrentUserName));
        }

        // GET: Public/Details/5
        [HttpGet]
        [Route("tickets/details/{id}")]
        public ActionResult TicketDetails(int id)
        {
            if (id < 0)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = sc.GetTicketByIdAsync(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View("TicketDetails", ticket);
        }

        // GET: Public/Create
        [Route("tickets/create")]
        public ActionResult CreateTicket()
        {
            ViewData["types"] = sc.GetTickTypes();
            ViewData["statuses"] = sc.GetTickStatuses();
            ViewData["urgencies"] = sc.GetTickUrgencies();
            return View("TicketCreate");
        }

        // POST: Public/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("tickets/create")]
        public async Task<ActionResult> CreateTicket([Bind(Include = "Title,Description,Urgency_Id,Type_Id,Required_By")] Ticket ticket)
        {
            var user = sc.GetUserAsync(WebSecurity.CurrentUserName);

            ticket.Raised_By = user.Id;

            if (ModelState.IsValid)
            {
                await sc.PostTicketAsync(ticket).ConfigureAwait(false);
                return RedirectToAction("tickets");
            }

            ViewData["types"] = sc.GetTickTypes();
            ViewData["statuses"] = sc.GetTickStatuses();
            ViewData["urgencies"] = sc.GetTickUrgencies();
            return View("TicketCreate", ticket);
        }

        // GET: Public/Edit/5
        [Route("tickets/edit")]
        public async Task<ActionResult> EditTicket(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = await db.Tickets.FindAsync(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View("TicketEdit", ticket);
        }

        // POST: Public/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("tickets/edit")]
        public async Task<ActionResult> Edit([Bind(Include = "Id,Reference,Title,Description,Raised,Status_Id,Completed_On,Urgency_Id,Type_Id,Raised_By,Needs_Approval,Approved_By,Required_By")] Ticket ticket)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ticket).State = EntityState.Modified;
                await db.SaveChangesAsync();
                return RedirectToAction("Tickets");
            }
            return View("TicketEdit", ticket);
        }

        // GET: Public/Delete/5
        public async Task<ActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = await db.Tickets.FindAsync(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }


    //--------------KNOWLEDGE---------------//

        //GET: public/knowledge
        [Route("knowledge")]
        [HttpGet]
        public ActionResult GetKnowledge()
        {
            string search = Request["search"];

            var knowl = sc.GetKnowledgeAsync(search);

            if (knowl == null)
            {
                return HttpNotFound();
            }

            return View("Knowledge", knowl);
        }

        //GET: public/knowledge
        [Route("knowledge/details/{id}")]
        [HttpGet]
        public ActionResult GetKnowledge(int id)
        {
            var knowl = sc.GetKnowledgeByIdAsync(id);

            if (knowl == null)
            {
                return HttpNotFound();
            }

            return View("KnowledgeView", knowl);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
