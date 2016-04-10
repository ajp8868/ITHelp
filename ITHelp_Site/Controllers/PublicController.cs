using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using ITHelp_Models;
using WebMatrix.WebData;
using ITHelp_Site.Filters;

/*
 * The Public controller for handling all requests made by a user in the viewer role.
 * @author Adam Postgate - M2095821
 * Email: ajp8868@aol.com
 */
namespace ITHelp_Site.Controllers
{
    [InitializeSimpleMembership]
    [Authorize(Roles="viewer")]
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
        [HttpGet]
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
        [Route("tickets/edit/{id}")]
        [HttpGet]
        public ActionResult EditTicket(int id)
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
            ViewBag.types = sc.GetTickTypes();
            ViewBag.urgencies = sc.GetTickUrgencies();
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
                await sc.PutTicketAsync(ticket).ConfigureAwait(false);
                return RedirectToAction("Tickets");
            }
            ViewBag.types = sc.GetTickTypes();
            ViewBag.urgencies = sc.GetTickUrgencies();
            return View("TicketEdit", ticket);
        }

        // GET: public/tickets/cancel/5
        [Route("tickets/cancel/{id}")]
        [HttpGet]
        public ActionResult CancelTicket(int id)
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

            return View("TicketCancel", ticket);
        }

        // GET: public/asset/cancel/5
        [Route("tickets/cancel/{id}")]
        [HttpPost]
        public ActionResult CancelTicketPut(int id)
        {
            Ticket ticket = sc.GetTicketByIdAsync(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }

            ticket.Cancelled_Reason = Request["Cancelled_Reason"];
            ticket.Cancelled = true;

            var x = sc.PutTicketAsync(ticket).Result;

            return RedirectToAction("tickets");
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
