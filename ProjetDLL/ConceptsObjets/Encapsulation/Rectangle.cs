using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDLL.ConceptsObjets.Encapsulation
{
    public class Rectangle
    {
        //Encapsulation: l'accés aux attributs d'une classe passe forcément par les Getteur/Setteur
        //Dans certaines applications sensibles - les champs et les propriétés sont en private

        private double _hauteur;

        private double Hauteur
        {
            get 
            {
                Console.WriteLine("Merci de saisir votre mot de passe:");
                string pass = Console.ReadLine();
                if (pass.Equals("Admin"))
                {
                    return _hauteur;
                }
                else
                {
                    Console.WriteLine("Accés refusé.....");
                    return 0;
                }
                
            }
            set 
            {
                if (value < 0)
                {
                    Console.WriteLine("La hauteur ne peut être négative");
                }
                else
                {
                    _hauteur = value;
                }
                
            }
        }

        private double _largeur;

        private double Largeur
        {
            get { return _largeur; }
            set { _largeur = value; }
        }

        public Rectangle(double hauteur, double largeur)
        {
            Hauteur = hauteur;
            Largeur = largeur;
        }

        public void Redim(double hauteur, double largeur)
        {
            Hauteur = hauteur;
            Largeur = largeur;
        }
    }
}
