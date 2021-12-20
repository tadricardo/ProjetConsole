using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDLL.Genericite
{
    public class Product
    {
        public string Description { get; set; }
        public double Price { get; set; }

     


        public override string ToString()
        {
            return $"Description: {Description} - Price: {Price}";
        }
    }
}
