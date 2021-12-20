using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDLL.SOLID.OpenClose.Good
{
    public class AreaCalculator
    {
        //Respecte le principe OPEN/CLOSE - Mise en place du polymorphisme en utilisant une interface
        public double ShapeArea(IShape s)
        {
            return s.Area();
        }
    }
}
