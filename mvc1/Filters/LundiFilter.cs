using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace mvc1.Filters
{
    public class LundiFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //Vérifier si on est le Lundi
            if (DateTime.Now.DayOfWeek != DayOfWeek.Monday)
            {
                throw new Exception("Action qui ne peut être exécutée que le Lundi.......");
            }
        }
    }
}