using ITHelp_Api.Tools;
using ITHelp_Models;
using System;
using System.Collections.Generic;
using System.Net.Http;
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
        [Route("api/users/{id}")]
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
        [Route("api/users{username}")]
        [HttpGet]
        public ActionResult GetUsersById(string username)
        {
            var items = sc.GetUsers();

            return JsonTools.SuccessfulJson(UserTools.checkByUsername(username, items));
        }

        // POST: api/urgencies
        [Route("api/users/")]
        [HttpPost]
        public HttpResponseMessage PostUser(User user)
        {
            return sc.PostUserAsync(user).Result;
        }

        // POST: api/tickets
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
            ticket.Raised = DateTime.Now;

            return sc.PostTicketAsync(ticket).Result;
        }
    }
}
