using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDLL.SOLID.LiskovSubstitution.Good
{
    public class Voiture : Vehicule
    {
        //Doit gardée l'implémentation des méthodes de la classe parente
        //2 Solutions:
        //1- ne pas redéinir la méthode demarrer()
        //2- Redéfinir la méthode en gardant son implémentation
    }
}
