using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDLL.SOLID.LiskovSubstitution.Good
{
    public class Vehicule
    {
        public virtual void demarrer()
        {
            Console.WriteLine("Véhicule démarré....");
        }
    }
}
