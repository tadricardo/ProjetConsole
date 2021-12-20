using AutoMapper;
using ExoMVC.Models;
using ExoMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExoMVC.Tools
{
    public class Convertisseur
    {
        //AutoMapper

        public static UtilisateurViewModel UtilisateurViewModelFromUtilisateur(UtilisateurViewModel viewModel, Utilisateur user)
        {
            //Configuration du Mapper
            //MapperConfiguration conf = new MapperConfiguration(cfg =>
            //{
            //    cfg.CreateMap<Utilisateur, UtilisateurViewModel>();
            //    cfg.CreateMap<UtilisateurViewModel, Utilisateur>();
            //});

            //Instanciation du Mapper
           // MapperTool.Configure(); -- Méthode appelée dans Global.asax (le premier fichier exécuté au démarrage de l'application
            IMapper mapper = MapperTool.Conf.CreateMapper();

            //Mapping
            viewModel = mapper.Map(user, viewModel);

            //viewModel.Id = user.Id;
            //viewModel.UserName = user.UserName;
            //viewModel.Password = user.Password;
            //viewModel.Email = user.Email;
            //viewModel.Photo = user.Photo;
            //viewModel.IsAdmin = user.IsAdmin;

            return viewModel;
        }

        internal static Utilisateur UtilisateurFromUtilisateurViewModel(UtilisateurViewModel viewModel, Utilisateur utilisateur)
        {
            //Configuration du Mapper
            //MapperConfiguration conf = new MapperConfiguration(cfg =>
            //{
            //    cfg.CreateMap<Utilisateur, UtilisateurViewModel>();
            //    cfg.CreateMap<UtilisateurViewModel, Utilisateur>();
            //});

            //Instanciation du Mapper
            //MapperTool.Configure();
            IMapper mapper = MapperTool.Conf.CreateMapper();

            //Mapping
            utilisateur = mapper.Map(viewModel, utilisateur);

            //utilisateur.Id = viewModel.Id;
            //utilisateur.UserName = viewModel.UserName;
            //utilisateur.Password = viewModel.Password;
            //utilisateur.Email = viewModel.Email;
            //utilisateur.Photo = viewModel.Photo;
            //utilisateur.IsAdmin = viewModel.IsAdmin;
            return utilisateur;
        }
    }
}