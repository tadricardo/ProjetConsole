using ExoMVC.Extensions;
using ExoMVC.Services;
using ExoMVC.Tools;
using ExoMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExoMVC.Controllers
{
    public class LoginController : Controller
    {
        private UtilisateurService service = new UtilisateurService();

        public ActionResult Accueil()
        {
            return View();
        }

        // GET: Login
        
        public ActionResult Index()
        {
            //throw new Exception("mmmmmmm");
            return View(new UtilisateurViewModel());
        }

        [HttpPost]
        public ActionResult Index(UtilisateurViewModel viewModel)
        {
            if (ModelState.IsValidField("UserName") && ModelState.IsValidField("Password"))
            {
                //Hasher le password
                //viewModel.Password = HashTool.CryptPassword(viewModel.Password); -- Rôle du service

                UtilisateurViewModel userVM = service.FindUserByUserNameAndPassword(viewModel);
                if (userVM != null)
                {
                    //Affichage page accueil
                    Session["user"] = userVM;
                    this.AddNotification("Bienvenue: " + viewModel.UserName, NotificationType.SUCCESS);
                    return RedirectToAction("Accueil");
                }
                else
                {
                    //ViewBag.Erreur = "Echec authentification.......";
                    this.AddNotification("Echec connexion......", NotificationType.ERROR);
                    return View(viewModel);
                }
            }
            else
            {
                //ViewBag.Erreur = "Echec authentification.......";
                this.AddNotification("Echec connexion......", NotificationType.ERROR);
                return View(viewModel);
            }
           
        }

        public ActionResult Logout()
        {
            Session.Clear();
            return RedirectToAction("Index");
        }

        public ActionResult Error404()
        {
            return View();
        }
    }
}