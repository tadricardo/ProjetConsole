using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDLL.SOLID.OpenClose.Good
{
    public class Triangle : IShape
    {
        public double Base { get; set; }
        public double Lenght { get; set; }
        public double Area()
        {
            return (Base * Lenght) / 2;
        }
    }
}
