using System.Threading.Tasks;
using System.Net;
using System.Web.Mvc;
using ITHelp_Models;
using WebMatrix.WebData;
using ITHelp_Site.Filters;
using Newtonsoft.Json;

/*
 * Admin controller for handling all requests made by a user in the Admin role.
 * @author Adam Postgate - M2095821
 * Email: ajp8868@aol.com
 */
namespace ITHelp_Site.Controllers
{
    [InitializeSimpleMembership]
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

     //---------------Users-------------------//

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
            return View("UserDetails", sc.GetUserByIdAsync(id));
        }

        // GET: Edit/Tickets
        [Route("users/edit/{id}")]
        public ActionResult EditUser(int id)
        {
            return View("UserEdit", sc.GetUserByIdAsync(id));
        }

        [Route("users/edit/{id}")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditUser(User user)
        {
            if (!ModelState.IsValid)
            {
                return View("UserEdit", user);
            }

            await sc.PostUserAsync(user).ConfigureAwait(false);

            return RedirectToAction("users");
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

        // GET: tickets/Create
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

        //POST: admin/tickets/create
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
            ticket.Approved_By = sc.GetUserAsync(User.Identity.Name).Id;

            return View("TicketApprove", ticket);
        }

        //--------------Knowledge----------------//

        //GET: knowledge
        [Route("knowledge")]
        [HttpGet]
        public ActionResult Knowledge()
        {
            string search = Request["search"];
            return View(sc.GetKnowledgeAsync(search));
        }

        //GET: knowledge
        [Route("knowledge/create")]
        [HttpGet]
        public ActionResult CreateKnowledge()
        {
            return View("knowledgecreate");
        }

        //GET: knowledge
        [Route("knowledge/create")]
        [HttpPost]
        public async Task<ActionResult> CreateKnowledge(Knowledge knowledge)
        {
            if (!ModelState.IsValid)
            {
                return HttpNotFound();
            }

            knowledge.Added_By = sc.GetUserAsync(User.Identity.Name).Id;

            var result = await sc.PostKnowledgeAsync(knowledge).ConfigureAwait(false);

            return RedirectToAction("knowledge");
        }

        // GET: Knowledge/Details/5
        [Route("Knowledge/details/{id}")]
        [HttpGet]
        public ActionResult KnowledgeDetails(int id)
        {
            var knowledge = sc.GetKnowledgeByIdAsync(id);

            return View("KnowledgeView", knowledge);
        }

        [Route("knowledge/edit/{id}")]
        [HttpGet]
        public ActionResult EditKnowledge(int id)
        {
            return View("knowledgeEdit", sc.GetKnowledgeByIdAsync(id));
        }

        [Route("knowledge/edit/{id}")]
        [HttpPost]
        public async Task<ActionResult> EditKnowledge(Knowledge knowledge, int id)
        {
            var x = await sc.PutKnowledgeAsync(knowledge).ConfigureAwait(false);

            return RedirectToAction("knowledge/details/" + id);
        }

        //-------------Assets-------------------//

        // GET: Assets
        [Route("assets")]
        public ActionResult Assets()
        {
            return View(sc.GetAssetsAsync());
        }

        // GET: Assets/edit
        [Route("assets/edit/{id}")]
        public ActionResult EditAsset(int id)
        {
            return View("AssetEdit", sc.GetAssetById(id));
        }

        // GET: Assets
        [Route("assets/edit/{id}")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<ActionResult> Assets(Asset asset)
        {
            if (!ModelState.IsValid)
            {
                return View("AssetEdit", asset);
            }

            await sc.PutAssetAsync(asset).ConfigureAwait(false);

            return RedirectToAction("assets/details/" + asset.Id.ToString());
        }

        [Route("assets/details/{id}")]
        public ActionResult Assets(int id)
        {
            var item = sc.GetAssetById(id);

            if (item == null)
            {
                return HttpNotFound();
            }

            return View("assetDetails", item);
        }

        // GET: Assets/create
        [Route("assets/create")]
        public ActionResult CreateAsset()
        {
            return View("AssetCreate");
        }

        // POST: Asset
        [Route("assets/create")]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public async Task<ActionResult> Create(Asset asset)
        {
            if (!ModelState.IsValid)
            {
                return View("AssetCreate", asset);
            }

            await sc.PostAssetAsync(asset).ConfigureAwait(false);

            return RedirectToAction("assets");
        }
    }
}
