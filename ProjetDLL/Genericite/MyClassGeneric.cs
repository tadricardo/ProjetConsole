using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDLL.Genericite
{
    public class MyClassGeneric<MyType> // where MyType : new() - doit contenir un constructeur par defaut
                                        // where MyType : CompteBancaire - doit hériter de CompteBancaire
    {
        public MyType A { get; set; }
        public MyType B { get; set; }

        public void Swap()
        {
            MyType C = A;
            A = B;
            B = C;
        }
    }
}
