using ExoMVC.Repositories;
using ExoMVC.Tools;
using ExoMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Hosting;
using System.Web.Mvc;

namespace ExoMVC.Services
{
    public class UtilisateurService
    {
        private UtilisateurRepository repo = new UtilisateurRepository();

        public UtilisateurViewModel FindUserByUserNameAndPassword(UtilisateurViewModel viewModel)
        {
            //Hasher le password
            viewModel.Password = HashTool.CryptPassword(viewModel.Password);
            UtilisateurViewModel userVM = repo.FindUserByUserNameAndPassword(viewModel);
            return userVM;
        }

        public List<UtilisateurViewModel> GetAllUtilisateur()
        {
            return repo.GetAllUtilisateur();
        }

        public void Add(UtilisateurViewModel viewModel, HttpPostedFileBase photo)
        {
            //Modifier le nom de l'image - sauvegarder l'image dans /Content/images
            viewModel.Photo = viewModel.Email + Path.GetExtension(photo.FileName);
            photo.SaveAs(HostingEnvironment.MapPath("~/Content/images/") + viewModel.Photo);
            
            //Hasher le password
            viewModel.Password = HashTool.CryptPassword(viewModel.Password);
            repo.Add(viewModel);
        }

      
    }
}