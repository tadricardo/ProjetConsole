using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDLL.SOLID.LiskovSubstitution.Bad
{
    public class Voiture : Vehicule
    {
        public override void demarrer()
        {
            Console.WriteLine("Voiture démarrée.....");
        }
    }
}
