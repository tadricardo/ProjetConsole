using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDLL.ConceptsObjets.Classes
{
    public class Screen
    {
        public string Model { get; set; }
        public double Price { get; set; }
        public static int NBScreens { get; set; }

        //Constructeur: méthode spéciale qui initialise les attributs non static (propres à l'objet)
        public Screen()
        {
            NBScreens++;
        }



        //Desctructeur: méthode appelée par le Garbage Collector
        ~Screen()
        {
            Console.WriteLine("Passage du Garbage Collector........");
            NBScreens--;
        }

        //Constructeur static : d'initialiser uniquement les attributs static - Ce contructeur est appelé de manière implicte dès la première utilisation de
        //la classe Screen
        static Screen()
        {
            NBScreens = 0;
            Console.WriteLine("Appel du construteur static - NBScreen initialisée à 0");
        }
    }
}
