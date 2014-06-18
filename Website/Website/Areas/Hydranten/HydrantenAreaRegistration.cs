using System.Web.Mvc;

namespace AlarmWorkflow.Website.Reports.Areas.Hydranten
{
    public class HydrantenAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "Hydranten";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "Hydranten_default",
                "Hydranten/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
