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
using System.Web.Security;
using WebMatrix.WebData;

namespace ITHelp_Site.Controllers
{
    [RoutePrefix("admin")]
    [Authorize(Roles = "admin")]
    public class AdminController : Controller
    {
        private ServiceConnector sc = new ServiceConnector();

        // GET: Tickets
        public ActionResult Index()
        {
            return View();
        }

        // GET: Tickets
        [Route("users")]
        public ActionResult Users()
        {
            return View(sc.GetUsersAsync());
        }

        // GET: Tickets
        [Route("users/details/{id}")]
        public ActionResult UserDetails(int id)
        {
            return View(sc.GetUserByIdAsync(id));
        }

        [Route("users")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddUser([Bind(Include = "Id,Name,User_Name,Password,Enabled,Admin,User_Group,Email,Phone_No")] User user)
        {
            if (ModelState.IsValid)
            {
                var res = await sc.PostUserAsync(user);

                if (res.IsSuccessStatusCode)
                {
                    return RedirectToAction("Admin/Users");
                }
            }
            return View(user);
        }

        // GET: Assets
        [Route("assets")]
        public ActionResult Assets()
        {
            return View(sc.GetAssetsAsync());
        }

//--------------TICKETS----------------//

        // GET: Tickets
        [Route("tickets")]
        [HttpGet]
        public ActionResult Tickets()
        {
            ViewBag.ticketfilter = new TicketFilter();
            return View(sc.GetTicketsAsync());
        }

        // GET: Tickets
        [Route("tickets", Order=0)]
        [HttpPost]
        public ActionResult Tickets(TicketFilter filter)
        {
            ViewBag.ticketfilter = new TicketFilter();
            return View(sc.GetTicketsWithParamsAsync(filter));
        }

        // GET: Tickets/Details/5
        [Route("tickets/details/{id}")]
        [HttpGet]
        public ActionResult Details(int id)
        {
            var ticket = sc.GetTicketByIdAsync(id);

            return View("TicketDetails", ticket);
        }

        // GET: knowledge/Create
        [Route("tickets/create")]
        [HttpGet]
        public ActionResult Create()
        {
            ViewData["types"] = sc.GetTickTypes();
            ViewData["statuses"] = sc.GetTickStatuses();
            ViewData["urgencies"] = sc.GetTickUrgencies();
            ViewData["users"] = sc.GetUsersAsync();
            return View("TicketCreate");
        }

        //POST: admin/knowledge/create
        [Route("tickets/create")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create([Bind(Include = "Title,Description,Urgency_Id,Type_Id,Required_By,Raised_By")] Ticket ticket)
        {
            var user = sc.GetUserAsync(WebSecurity.CurrentUserName);

            ticket.Raised_By = user.Id;
            ticket.User_Raised = user;

            if (ModelState.IsValid)
            {
                await sc.PostTicketAsync(ticket).ConfigureAwait(false);
                return RedirectToAction("tickets");
            }

            ViewData["types"] = sc.GetTickTypes();
            ViewData["statuses"] = sc.GetTickStatuses();
            ViewData["urgencies"] = sc.GetTickUrgencies();
            ViewData["users"] = sc.GetUsersAsync();
            return View("TicketCreate",ticket);
        }

        // GET: Tickets/Edit/5
        [Route("tickets/edit/{id}")]
        [HttpGet]
        public ActionResult Edit(int id)
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
            ViewData["types"] = sc.GetTickTypes();
            ViewData["statuses"] = sc.GetTickStatuses();
            ViewData["urgencies"] = sc.GetTickUrgencies();
            ViewData["users"] = sc.GetUsersAsync();
            return View("TicketEdit", ticket);
        }

        // GET: Tickets/Edit/5
        [Route("tickets/edit")]
        [HttpPost]
        public async Task<ActionResult> Edit(Ticket ticket)
        {
            var x = await sc.PutTicketAsync(ticket).ConfigureAwait(false);

            return RedirectToAction("Tickets");
        }

        // GET: Tickets/Approve/5
        [Route("tickets/Approve/{id}")]
        [HttpGet]
        public ActionResult Approve(int id)
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

            return View("TicketApprove", ticket);
        }

        //--------------Knowledge----------------//

        //GET: knowledge
        [Route("knowledge{search}")]
        [HttpGet]
        public ActionResult Knowledge(string search)
        {
            return View(sc.GetKnowledgeAsync(search));
        }

        // GET: Knowledge/Details/5
        [Route("Knowledge/details/{id}")]
        [HttpGet]
        public ActionResult KnowledgeDetails(int id)
        {
            var knowledge = sc.GetKnowledgeByIdAsync(id);

            return View("KnowledgeView", knowledge);
        }

    }
}
