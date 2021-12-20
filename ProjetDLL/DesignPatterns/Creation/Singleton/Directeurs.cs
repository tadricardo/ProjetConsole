using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDLL.DesignPatterns.Creation.Singleton
{
    public class Directeurs
    {
        //Objectif: avoir qu'un seul et unique objet Directeur dans toute l'application
        public string  Name { get; set; }

        //Gestion d'une ressource partagée
        public static object verrou = new object();

        //Interdire l'accés au constructeur
        private Directeurs()
        {

        }

        //Ajouter une propriété static de type Directeur en lecture seule pour avoir l'instance en question
        private static Directeurs instance;

        public static Directeurs Instance
        {
            get
            {
                if (instance == null)
                {
                    //Vérrouillage de la ressource
                    lock (verrou)
                    {
                        instance = new Directeurs();
                    }
                }
                return instance;
            }
        }
    }
}
