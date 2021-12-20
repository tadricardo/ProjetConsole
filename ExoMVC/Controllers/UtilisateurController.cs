using ExoMVC.Services;
using ExoMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExoMVC.Controllers
{
    public class UtilisateurController : Controller
    {
        private UtilisateurService service = new UtilisateurService();

        // GET: Utilisateur
        public ActionResult Index(string search, string sortBy, int page=0)
        {
            List<UtilisateurViewModel> lst = service.GetAllUtilisateur();

            //Filtre
            if (search != null)
            {
                lst = lst.Where(u => u.UserName.Contains(search)).ToList();
            }

            //Tri
            if (sortBy != null)
            {
                switch (sortBy)
                {
                    case "asc":
                        lst = lst.OrderBy(u => u.UserName).ToList();
                        break;
                    case "desc":
                        lst = lst.OrderByDescending(u => u.UserName).ToList();
                        break;
                    default:
                        break;
                }
            }

            //Pagination
            int pageSize = 2;

            //if (page < 0)
            //{
            //    page = 0;
            //}
            //else
            //{
            //    page = page;
            //}
            page = (page < 0) ? 0 : page; //opérateur ternaire

            ViewBag.PreviousPage = page - 1;
            ViewBag.NextPage = page + 1;
            ViewBag.Page = page + 1;

            //Nombre de pages totales
            int pagesTotales = 0;
            if( (lst.Count % pageSize) == 0)
            {
                pagesTotales = lst.Count / pageSize;
            }
            else
            {
                pagesTotales = (lst.Count / pageSize) + 1;
            }

            ViewBag.Totales = pagesTotales;

            lst = lst.Skip(page * pageSize).Take(pageSize).ToList();

            if (lst.Count < pageSize)
            {
                ViewBag.NextPage = page;
            }
            else
            {
                ViewBag.NextPage = page + 1;
            }



            return View(lst);
        }

        public ActionResult Create()
        {
            //Dictionnaires: clé - valeur
            //ViewBag.Partial = "create"; ne matient pas les données entre 2 actions
            //ViewData["Partial"] = "create"; ne matient pas les données entre 2 actions
            TempData["Partial"] = "create"; //permet de maintenir les données entre les différentes actions
            //Session["Partial"] = "create"; // permet de maintenir les données pendant toute la durée de la session (limitée à 20 mn par defaut)
            //Session.Timeout = 2; //maintient les données pendant 2 mn
            return RedirectToAction("Index");
        }
    }
}