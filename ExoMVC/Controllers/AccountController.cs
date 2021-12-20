using ExoMVC.Services;
using ExoMVC.Tools;
using ExoMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExoMVC.Controllers
{
    public class AccountController : Controller
    {
        private UtilisateurService service = new UtilisateurService();

        // GET: Account
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(UtilisateurViewModel viewModel, HttpPostedFileBase photo)
        {
            if (ModelState.IsValid)
            {
                //Modifier le nom de l'image - sauvegarder l'image dans /Content/images
                //viewModel.Photo = viewModel.Email + Path.GetExtension(photo.FileName);
                //photo.SaveAs(Server.MapPath("~/Content/images/") + viewModel.Photo); --- Rôle Service

                //Hasher le password
                //viewModel.Password = HashTool.CryptPassword(viewModel.Password); -- Rôle du service

                service.Add(viewModel, photo);

                return RedirectToAction("Index", "Login");
            }
            else
            {
                return View(viewModel);
            }
           
        }
    }
}