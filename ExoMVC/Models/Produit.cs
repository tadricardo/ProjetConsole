using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ExoMVC.Models
{
    public class Produit
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Quantite { get; set; }
    }
}