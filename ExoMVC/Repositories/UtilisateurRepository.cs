using ExoMVC.Models;
using ExoMVC.Tools;
using ExoMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExoMVC.Repositories
{
    public class UtilisateurRepository
    {
        public UtilisateurViewModel FindUserByUserNameAndPassword(UtilisateurViewModel viewModel)
        {
            UtilisateurViewModel userVM = null;
            using (var context = new MyContext())
            {
                Utilisateur user = context.Utilisateurs.FirstOrDefault(u => u.UserName == viewModel.UserName && u.Password == viewModel.Password);
                if (user != null)
                {
                    userVM = Convertisseur.UtilisateurViewModelFromUtilisateur(viewModel, user);
                }
            }
            return userVM;
        }

        public List<UtilisateurViewModel> GetAllUtilisateur()
        {
            List<UtilisateurViewModel> list = new List<UtilisateurViewModel>();
            using (var context = new MyContext())
            {
                List<Utilisateur> users = context.Utilisateurs.ToList();
                foreach (var user in users)
                {
                    list.Add(Convertisseur.UtilisateurViewModelFromUtilisateur(new UtilisateurViewModel(), user));
                }
            }

            return list;
        }

        public void Add(UtilisateurViewModel viewModel)
        {
            Utilisateur user = Convertisseur.UtilisateurFromUtilisateurViewModel(viewModel, new Utilisateur());
            using (var context = new MyContext())
            {
                context.Utilisateurs.Add(user);
                context.SaveChanges();
            }
        }
    }
}