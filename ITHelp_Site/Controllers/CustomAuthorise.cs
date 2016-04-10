using System.Web.Mvc;
using System.Web.Routing;
/*
 * Meant to show a standard error page if an unauthorized user tries to access a page. This doesn't work currently
 * @author Adam Postgate - M2095821
 * Email: ajp8868@aol.com
 */
public class CustomAuthorize : AuthorizeAttribute
{
    protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
    {
        if (!filterContext.HttpContext.User.Identity.IsAuthenticated)
        {
            //base.HandleUnauthorizedRequest(filterContext);
            filterContext.Result = new RedirectToRouteResult(new
            RouteValueDictionary(new { controller = "Error", action = "Index" }));
        }
        else
        {
            filterContext.Result = new RedirectToRouteResult(new
            RouteValueDictionary(new { controller = "Error", action = "Index" }));
        }
    }
}
