using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ExoMVC.ViewModels
{
    public class UtilisateurViewModel
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "User Name obligatoire")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Mot de passe obligatoire")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        public bool IsAdmin { get; set; }

        [EmailAddress]
        [Required(ErrorMessage = "Email obligatoire")]
        public string Email { get; set; }
        public string Photo { get; set; }
    }
}