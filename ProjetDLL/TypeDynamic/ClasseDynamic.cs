using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDLL.TypeDynamic
{
    public class ClasseDynamic
    {
        public static dynamic Additionner(dynamic param1, dynamic param2)
        {
            return param1 + param2;
        }
    }
}
