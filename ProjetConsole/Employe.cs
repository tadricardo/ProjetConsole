using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetConsole
{
   public class Employe : object
    {
        public string Nom { get; set; }
        public string Prenom { get; set; }

        public Employe(string nom, string prenom)
        {
            Nom = nom;
            Prenom = prenom;
        }

        public Employe()
        {
            Nom = "TOTO";
            Prenom = "TATA";
        }

        public void Afficher()
        {
            Console.WriteLine($"Nom: {Nom} - Prénom: {Prenom}");
        }
    }
}
