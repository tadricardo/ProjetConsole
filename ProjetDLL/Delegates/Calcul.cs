using ProjetDLL.Genericite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDLL.Delegates
{
    public class Calcul
    {
        //Un delegate nous permet de définir une signature de méthode
        public delegate int Operation(int x, int y);

        public static int Somme(int x, int y)
        {
            Console.WriteLine("Somme: "+ (x+y));
            return x + y;
        }

        public static int Soustraction(int x, int y)
        {
            return x - y;
        }

        //public static int Multiplication(int x, int y)
        //{
        //    return x * y;
        //}

        //Le client récupère une liste de produits à partir d'une source (BD, Fichiers....), modifie cette liste ensuite envoie la liste une vue MVC

        public enum Modification
        {
            AJOUT,
            SUPPRESSION,
            CHANGER_PRIX,
            MODIFICATION,
            MODIF_NOM
        }
        public static List<Product> GetAll(List<Product> lst, Func<List<Product>, List<Product>> modif)
        {
            return modif(lst);
        }
    }
}
