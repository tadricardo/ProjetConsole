using ExoMVC.App_Start;
using ExoMVC.Tools;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ExoMVC
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);

            //Configuration du Mapper
            MapperTool.Configure();

            //Déclaration du filtre global HandleError
            FilterConfig.RegisterGlobalFilter(GlobalFilters.Filters);
        }
    }
}
