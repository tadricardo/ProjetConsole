using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDLL.ConceptsObjets.Polymorphisme
{
    public class PolyTest  
    {
       //Mise en place du polymorphisme

        //Objectif: appel des méthode Plier - Deplier

        //ad-hoc: mise en place du polymorphisme au niveau des params avec GetType - Cast
        public static void Acheter(object obj)
        {
            //Vérification du type
            if (obj.GetType().Equals(typeof(IPliable)))
            {
                //Cast
                IPliable p = (IPliable)obj;
                p.Plier();
                p.Deplier();
            }
        }

        //Polymorphisme par sous-typage
        public static void Acheter(IPliable p)
        {
            //Pas besoin de faire des vérifications ni de CAST 
            p.Plier();
            p.Deplier();
        }

        //Polymorphisme par type paramétrique - Généricité
        public static void Acheter<T>(T obj) where T : IPliable
        {
            //Pas besoin de faire des vérifications ni de CAST
            obj.Plier();
            obj.Deplier();
        }
     }
}
