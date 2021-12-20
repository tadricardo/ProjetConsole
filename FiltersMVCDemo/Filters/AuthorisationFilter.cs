﻿using FiltersMVCDemo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FiltersMVCDemo.Filters
{
    public class AuthorisationFilter : AuthorizeAttribute
    {
        private string[] allowedRoles;

        public AuthorisationFilter(params string[] allowedRoles)
        {
            this.allowedRoles = allowedRoles;
        }

        //Traiter les requêtes autorisée

        protected override bool AuthorizeCore(HttpContextBase httpContext)
        {
            //Récupérer le username stocké en session
            string username = (string)httpContext.Session["username"];
            bool autorize = false;

            if (!string.IsNullOrEmpty(username))
            {
                //Récupérer le role du user depuis la BD
                using (var context = new MyContext())
                {
                    var userRole = (from u in context.Users
                                   join r in context.Roles on u.RoleId equals r.Id
                                   where u.UserName == username
                                   select new { r.Name }).FirstOrDefault();

                    //Vérifier si userRole est contenu dans le tableau allowedRoles

                    foreach (var role in allowedRoles)
                    {
                        if (role == userRole.Name)
                        {
                            //User autorisé à executer l'action
                            autorize = true;
                        }
                    }
                }

            }
            return autorize;
        }


        //Traiter les requêtes non autorisées - si autorize = false --- cette méthode sera executée

        protected override void HandleUnauthorizedRequest(AuthorizationContext filterContext)
        {
            //Redirection vers /Home/NonAutoriser
            filterContext.HttpContext.Response.Redirect("~/Home/NonAutoriser");
        }





    }
}