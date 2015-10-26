using System.Web.Mvc;

using OSky.Web.Mvc.Routing;


namespace OSky.UI.Admin.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapLowerCaseUrlRoute(
                "Admin_default",
                "admin/{controller}/{action}/{id}",
                new { controller="Home", action = "Index", id = UrlParameter.Optional },
                new[] { "OSky.UI.Admin.Areas.Admin.Controllers" }
                );
        }
    }
}