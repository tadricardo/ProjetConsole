using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDLL.SOLID.OpenClose.Good
{
    public class Rectangles : IShape

    {
        public double Lenght { get; set; }
        public double Width { get; set; }
        public double Area()
        {
            return Lenght * Width;
        }
    }
}
