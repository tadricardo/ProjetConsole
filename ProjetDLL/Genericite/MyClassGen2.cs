using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDLL.Genericite
{
   public  class MyClassGen2
    {
        public object A { get; set; }
        public object B { get; set; }

        public void Swap()
        {
            object C = A;
            A = B;
            B = C;
        }
    }
}
