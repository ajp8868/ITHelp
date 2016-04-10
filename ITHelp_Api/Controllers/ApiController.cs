using ITHelp_Api.Tools;
using ITHelp_Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

/*
 * API controller for the IT Help web application. All http methods are held in this controller.
 * @author Adam Postgate - M2095821
 * Email: ajp8868@aol.com
 */
namespace ITHelp_Api.Controllers
{
    [AllowAnonymous]
    public class ApiController : Controller
    {
        //---------------Globals------------------//

        private ServiceConnector sc = new ServiceConnector();


        //--------------Tickets------------------//

        // GET: api/tickets
        //gets all tickets from the dataservice
        [Route("api/tickets/")]
        [HttpGet]
        public ActionResult GetAllTickets()
        {
            return JsonTools.SuccessfulJson(sc.GetTickets());
        }

        //GET: api/tickets/filter
        //gets all tickets from the dataservice that match the filter criteria
        [Route("api/tickets/filter/")]
        [HttpPost]
        public ActionResult GetAllTickets(TicketFilter filter)
        {
            var tickets = sc.GetTickets();

            if (filter != null)
            {
                tickets = TicketTools.checkByFilter(filter, tickets);
            }

            return JsonTools.SuccessfulJson(tickets);
        }

        // GET: api/tickets/statuses
        //gets all ticket statuses
        [Route("api/tickets/statuses")]
        [HttpGet]
        public ActionResult GetTickStatuses()
        {
            return JsonTools.SuccessfulJson(sc.GetTickStatuses());
        }

        // GET: api/tickets/types
        //Gets all ticket types
        [Route("api/tickets/types")]
        [HttpGet]
        public ActionResult GetTickTypes()
        {
            return JsonTools.SuccessfulJson(sc.GetTickTypes());
        }

        // GET: api/tickets/urgencies
        //gets all ticket urgencies
        [Route("api/tickets/urgencies")]
        [HttpGet]
        public ActionResult GetTickUrgencies()
        {
            return JsonTools.SuccessfulJson(sc.GetTickUrgencies());
        }

        // GET: api/tickets/{id}/
        //Gets a ticket by Id
        [Route("api/tickets/{id}/")]
        [HttpGet]
        public ActionResult GetTicketsById(int id)
        {
            var items = sc.GetTickets(id);

            return JsonTools.SuccessfulJson(items[items.Count - 1]);
        }

        //Gets all tickets by the user that added them
        [Route("api/tickets/user/{username}/")]
        [HttpGet]
        public ActionResult GetTicketByUser(string username)
        {
            var items = sc.GetTickets();

            return JsonTools.SuccessfulJson(TicketTools.checkByUser(username, items));
        }


        // POSTs a ticket
        [Route("api/tickets/")]
        [HttpPost]
        public HttpResponseMessage PostTicket(Ticket ticket)
        {
            if (ticket.Title.Length > 4)
            {
                ticket.Reference = DateTime.Now.ToString("ddMMyyyy-mmss") + ticket.Title.Substring(0, 5).Replace(" ", "");
            }
            else
            {
                ticket.Reference = DateTime.Now.ToString("ddMMyyyy-mmss") + ticket.Title.Replace(" ", "");
            }

            if (ticket.Type_Id == 4 || ticket.Type_Id == 5)
            {
                ticket.Status_Id = 1;
                ticket.Needs_Approval = true;
            }
            else
            {
                ticket.Status_Id = 2;
                ticket.Needs_Approval = false;
            }

            ticket.Raised = DateTime.Now;

            return sc.PostTicketAsync(ticket).Result;
        }

        // PUTs a ticket
        [Route("api/tickets/")]
        [HttpPut]
        public async Task<HttpResponseMessage> PutTicket(Ticket ticket)
        {
            if (!ModelState.IsValid)
            { return new HttpResponseMessage(HttpStatusCode.BadRequest); }
            else
            {
                TicketTools.CreateHistory(sc, ticket);
                return await sc.PutTicketAsync(ticket).ConfigureAwait(false);
            }
        }


        //---------------------Assets---------------------//

        //GETs all assets
        [Route("api/Assets/")]
        [HttpGet]
        public ActionResult GetAllAssets()
        {
            return JsonTools.SuccessfulJson(sc.GetAssets());
        }

        //GETs an Asset by Id
        [Route("api/Assets/{id}")]
        [HttpGet]
        public ActionResult GetAllAssets(int id)
        {
            var items = sc.GetAssets(id);

            return JsonTools.SuccessfulJson(items[items.Count -1]);
        }

        //PUTs an asset
        [Route("api/Assets/")]
        [HttpPut]
        public ActionResult PutAsset(Asset asset)
        {
            if (!ModelState.IsValid)
            {
                return HttpNotFound();
            }

            return JsonTools.SuccessfulJson(sc.PutAssetAsync(asset).Result);
        }

        //POSTs an asset
        [Route("api/Assets/")]
        [HttpPost]
        public ActionResult PostAsset(Asset asset)
        {
            if (!ModelState.IsValid)
            {
                return HttpNotFound();
            }

            return JsonTools.SuccessfulJson(sc.PostAssetAsync(asset).Result);
        }

        //----------------------Users---------------------//

        // GETs all users
        [Route("api/users/")]
        [HttpGet]
        public ActionResult GetAllUsers()
        {
            var items = sc.GetUsers();

            return JsonTools.SuccessfulJson(items);
        }

        // GETs a user by ID
        [Route("api/user/id/{id}")]
        [HttpGet]
        public ActionResult GetUsersById(int id)
        {
            var items = sc.GetUsers(id);

            return JsonTools.SuccessfulJson(items[items.Count - 1]);
        }

        // GETs a user by username
        [Route("api/user/{username}")]
        [HttpGet]
        public ActionResult GetUserByUsername(string username)
        {
            var items = sc.GetUsers();

            try
            {
                return JsonTools.SuccessfulJson(UserTools.checkByUsername(username, items));
            }
            catch (Exception e)
            {
                return JsonTools.UnsuccessfulJson(e.ToString());
            }

        }

        // POSTs a user
        [Route("api/users")]
        [HttpPost]
        public async Task<HttpResponseMessage> PostUser(User user)
        {
            return await sc.PostUserAsync(user).ConfigureAwait(false);
        }

        // PuTs a user
        [Route("api/users")]
        [HttpPost]
        public async Task<HttpResponseMessage> PutUser(User user)
        {
            return await sc.PutUserAsync(user).ConfigureAwait(false);
        }


        //--------------------Knowledge---------------//

        // GETs all knowledge
        [Route("api/knowledge")]
        [HttpGet]
        public ActionResult GetKnowledge()
        {
            string search = Request["search"];
            var items = sc.GetKnowledge();

            if (items == null)
            {
                return HttpNotFound();
            }

            if (search != null)
            {
                return JsonTools.SuccessfulJson(KnowledgeTools.CheckBySearch(search, items));
            }
            else
            {
                return JsonTools.SuccessfulJson(items);
            }
        }

        // GETs all knowledge by Id
        [Route("api/knowledge/{id}")]
        [HttpGet]
        public ActionResult GetKnowledge(int id)
        {
            var items = sc.GetKnowledge(id);

            if (items == null)
            {
                return HttpNotFound();
            }

            return JsonTools.SuccessfulJson(items[items.Count - 1]);
        }

        // PUTs a knowledge object
        [Route("api/knowledge")]
        [HttpPut]
        public ActionResult PutKnowledge(Knowledge knowl)
        {
            if (!ModelState.IsValid)
            {
                return HttpNotFound();
            }

            knowl.Last_Updated = DateTime.Now;
            knowl.Revision += 1;

            return JsonTools.SuccessfulJson(sc.PutKnowledgeAsync(knowl).Result);
        }

        // POSTs a knowledge object
        [Route("api/knowledge")]
        [HttpPost]
        public ActionResult PostKnowledge(Knowledge knowl)
        {
            if (!ModelState.IsValid)
            {
                return HttpNotFound();
            }

            knowl.Added_On = DateTime.Now;
            knowl.Last_Updated = DateTime.Now;
            knowl.Revision = 0;

            return JsonTools.SuccessfulJson(sc.PostKnowledgeAsync(knowl).Result);
        }
    }
}
