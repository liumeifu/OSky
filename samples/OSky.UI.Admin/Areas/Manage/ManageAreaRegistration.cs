using System.Web.Mvc;

using OSky.Web.Mvc.Routing;


namespace OSky.UI.Admin.Areas.Manage
{
    public class ManageAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "Manage";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            context.MapLowerCaseUrlRoute(
                "Manage_default",
                "Manage/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new[] { "OSky.UI.Admin.Areas.Manage.Controllers" }
            );
        }
    }
}