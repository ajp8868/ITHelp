using ITHelp_Api.Tools;
using System.Collections.Generic;
using System.Web.Mvc;

namespace ITHelp_Api.Controllers
{
    [AllowAnonymous]
    public class ApiController : Controller
    {

        // GET: api/Api/5
        [Route("api/tickets/")]
        [HttpGet]
        public ActionResult GetAllTickets()
        {
            return JsonTools.SuccessfulJson(new ServiceConnector().GetTicketsAsync());
        }

        // GET: api/Api/5
        [Route("api/Assets/")]
        [HttpGet]
        public ActionResult GetAllAssets()
        {
            return JsonTools.SuccessfulJson(new ServiceConnector().GetAssetsAsync());
        }

        // DELETE: api/Api/5
        public void Delete(int id)
        {
        }
    }
}
