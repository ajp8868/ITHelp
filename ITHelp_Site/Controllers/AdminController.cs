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
        public ActionResult Tickets()
        {
            return View(sc.GetTicketsAsync());
        }

        // GET: Tickets
        public ActionResult Users()
        {
            return View(sc.GetUsersAsync());
        }

        // GET: Tickets/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var ticket = sc.GetTicketByIdAsync(id);

            return View(ticket);
        }

        // GET: Tickets/Create
        public ActionResult Create()
        {
            return View();
        }

        // GET: Tickets/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Ticket ticket = sc.GetTicketByIdAsync(id);
            if (ticket == null)
            {
                return HttpNotFound();
            }
            return View(ticket);
        }

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

    }
}
