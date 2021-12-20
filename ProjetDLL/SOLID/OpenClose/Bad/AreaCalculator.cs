using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDLL.SOLID.OpenClose.Bad
{
    public class AreaCalculator
    {
        //Open-Close:
        //A chaque ajout d'une nouvelle forme géométrique, on doit ajouter une nouvelle méthode pour calculer sa surface
        //Cette classe ne respecte pas le principe Open-Close - n'est pas fermée à la modification

        public double RectangleArea(Rectangles rec)
        {
            return rec.Lenght * rec.Width;
        }

        public double CircleArea(Circle c)
        {
            //PI * rayon au carré
            return Math.PI * Math.Pow(c.Radius, 2);
        }
    }
}
