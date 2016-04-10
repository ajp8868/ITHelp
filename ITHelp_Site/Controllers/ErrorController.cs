using System.Web.Mvc;

/*
 * should show the error message when directed to from the CustomAuthorize class, however this did not work.
 * @author Adam Postgate - M2095821
 * Email: ajp8868@aol.com
 */
namespace ITHelp_Site.Controllers
{
    public class ErrorController : Controller
    {
        public ActionResult Index()
        {
            return View("AdminError");
        }
    }
}
