using ITHelp_Api.Tools;
using ITHelp_Models;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace ITHelp_Api.Controllers
{
    [AllowAnonymous]
    public class ApiController : Controller
    {
        private ServiceConnector sc = new ServiceConnector();

        // GET: api/Api/5
        [Route("api/tickets/")]
        [HttpGet]
        public ActionResult GetAllTickets()
        {
            return JsonTools.SuccessfulJson(sc.GetTickets());
        }

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

        // GET: api/Api/5
        [Route("api/tickets/statuses")]
        [HttpGet]
        public ActionResult GetTickStatuses()
        {
            return JsonTools.SuccessfulJson(sc.GetTickStatuses());
        }

        // GET: api/Api/5
        [Route("api/tickets/types")]
        [HttpGet]
        public ActionResult GetTickTypes()
        {
            return JsonTools.SuccessfulJson(sc.GetTickTypes());
        }

        // GET: api/Api/5
        [Route("api/tickets/urgencies")]
        [HttpGet]
        public ActionResult GetTickUrgencies()
        {
            return JsonTools.SuccessfulJson(sc.GetTickUrgencies());
        }

        // GET: api/Api/5
        [Route("api/tickets/{id}/")]
        [HttpGet]
        public ActionResult GetTicketById(int id)
        {
            var items = sc.GetTickets();

            return JsonTools.SuccessfulJson(TicketTools.checkById(id, items));
        }

        // GET: api/Api/5
        [Route("api/tickets/user/{username}/")]
        [HttpGet]
        public ActionResult GetTicketById(string username)
        {
            var items = sc.GetTickets();

            return JsonTools.SuccessfulJson(TicketTools.checkByUser(username, items));
        }

        // GET: api/Api/5
        [Route("api/Assets/")]
        [HttpGet]
        public ActionResult GetAllAssets()
        {
            return JsonTools.SuccessfulJson(sc.GetAssets());
        }

        // DELETE: api/Api/5
        public void Delete(int id)
        {
        }

        // GET: api/Api/5
        [Route("api/users/")]
        [HttpGet]
        public ActionResult GetAllUsers()
        {
            var items = sc.GetUsers();

            return JsonTools.SuccessfulJson(items);
        }

        // GET: api/Api/5
        [Route("api/user/id/{id}")]
        [HttpGet]
        public ActionResult GetUsersById(int id)
        {
            var items = sc.GetUsers();

            return JsonTools.SuccessfulJson(UserTools.checkById(id, items));
        }

        // GET: api/Api/5
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

        // GET: api/Api/5
        [Route("api/users/id/{id}")]
        [HttpGet]
        public ActionResult GetUserById(int id)
        {
            var items = sc.GetUsers();

            return JsonTools.SuccessfulJson(UserTools.checkById(id, items));
        }



        // POST: api/urgencies
        [Route("api/users/")]
        [HttpPost]
        public HttpResponseMessage PostUser(User user)
        {
            return sc.PostUserAsync(user).Result;
        }

        // POST: api/knowledge
        [Route("api/tickets/")]
        [HttpPost]
        public HttpResponseMessage PostTicket(Ticket ticket)
        {
            if (ticket.Title.Length > 4)
            {
                ticket.Reference = DateTime.Now.ToString("ddMMyyyy-mmss") + ticket.Title.Substring(0, 5);
            }
            else
            {
                ticket.Reference = DateTime.Now.ToString("ddMMyyyy-mmss") + ticket.Title;
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

        // PUT: api/knowledge
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

        // GET: api/Knowledge{searchstring}
        [Route("api/knowledge")]
        [HttpGet]
        public ActionResult GetKnowledge()
        {
            string search = Request["search"];
            var items = sc.GetKnowledge();

            if (search != null)
            {
                KnowledgeTools.CheckBySearch(search, items);

                return JsonTools.SuccessfulJson(items);
            }
            else
            {
                return JsonTools.SuccessfulJson(items);
            }
        }

        // GET: api/Knowledge{searchstring}
        [Route("api/knowledge/{id}")]
        [HttpGet]
        public ActionResult GetKnowledge(int id)
        {
            var items = sc.GetKnowledge();

            return JsonTools.SuccessfulJson(KnowledgeTools.CheckById(id, items));
        }
    }
}
