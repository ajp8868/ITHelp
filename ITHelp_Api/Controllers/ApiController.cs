using ITHelp_Api.Tools;
using ITHelp_Models;
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
        [Route("api/tickets/{id}/")]
        [HttpGet]
        public ActionResult GetTicketById(int id)
        {
            var items = sc.GetTickets();

            return JsonTools.SuccessfulJson(TicketTools.checkById(id, items));
        }

        // GET: api/Api/5
        [Route("api/tickets{username?}/")]
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
        [Route("api/users{username?}")]
        [HttpGet]
        public ActionResult GetUsersById(string username)
        {
            var items = sc.GetUsers();

            return JsonTools.SuccessfulJson(UserTools.checkByUsername(username, items));
        }

        // POST: api/Api/5
        [Route("api/users/")]
        [HttpPost]
        public HttpResponseMessage PostUser(User user)
        {
            return (sc.PostUserAsync(user).Result);
        }
    }
}
