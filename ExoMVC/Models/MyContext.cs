using System;
using System.Data.Entity;
using System.Linq;

namespace ExoMVC.Models
{
    public class MyContext : DbContext
    {
       
        public MyContext()
            : base("name=MyContext")
        {
        }

        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<Produit> Produits { get; set; }
    }

    
}