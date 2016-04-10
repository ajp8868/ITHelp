using ITHelp_Site.Filters;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using WebMatrix.WebData;

/*
 * Auto generated home controller. Alterations have been made to redirect a user to the most relevant page on login.
 * @author Adam Postgate - M2095821
 * Email: ajp8868@aol.com
 */
namespace ITHelp_Site.Controllers
{
    [InitializeSimpleMembership]
    [AllowAnonymous]
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            if (WebSecurity.IsAuthenticated)
            {
                var userRoles = Roles.GetRolesForUser(WebSecurity.CurrentUserName);

                if (userRoles.Contains("admin"))
                {
                    return RedirectToLocal("/admin");
                }
                else if (userRoles.Contains("viewer"))
                {
                    return RedirectToLocal("/public");
                }
                else
                {
                    return View();
                }
            }
            else
            {
                return View();
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your app description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        private ActionResult RedirectToLocal(string returnUrl)
        {
            if (Url.IsLocalUrl(returnUrl))
            {
                return Redirect(returnUrl);
            }
            else
            {
                return RedirectToAction("Index", "Home");
            }
        }
    }
}
