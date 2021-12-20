using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDLL.DesignPatterns.Creation.Prototype
{
    public class Article : ICloneable
    {
        public string Description { get; set; }
        public double Price { get; set; }

        public object Clone()
        {
            return this.MemberwiseClone();
        }

        public override string ToString()
        {
            return $"Article: Description = {Description} - Price = {Price}";
        }
    }
}
