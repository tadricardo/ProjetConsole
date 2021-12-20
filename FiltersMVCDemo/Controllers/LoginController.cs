using FiltersMVCDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FiltersMVCDemo.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View(new User());
        }

        [HttpPost]
        public ActionResult Index(User u)
        {
            using (var context = new MyContext())
            {
                var userDB = context.Users.Where(user => user.UserName == u.UserName && user.Password == u.Password).FirstOrDefault();
                if (userDB != null)
                {
                    Session["username"] = userDB.UserName;
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ViewBag.Erreur = "Echec connexion......";
                    return View(u);
                }
            }
            
        }

        public ActionResult Logout()
        {
            //Session.Abandon();
            Session.Clear();
            // Session["username"] = null;

            return RedirectToAction("Index");
        }
    }
}