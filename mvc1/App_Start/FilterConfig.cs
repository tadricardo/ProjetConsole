using mvc1.Filters;
using System.Web;
using System.Web.Mvc;

namespace mvc1
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());

            //Ajout d'un filtre global
            //filters.Add(new LundiFilter());
        }
    }
}
