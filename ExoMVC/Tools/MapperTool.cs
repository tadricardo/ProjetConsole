using AutoMapper;
using ExoMVC.Models;
using ExoMVC.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExoMVC.Tools
{
    public class MapperTool
    {
        public static MapperConfiguration Conf { get; set; }

        public static MapperConfiguration Configure()
        {
            Conf = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Utilisateur, UtilisateurViewModel>();
                cfg.CreateMap<UtilisateurViewModel, Utilisateur>();
            });
            return Conf;
        }

    }
}