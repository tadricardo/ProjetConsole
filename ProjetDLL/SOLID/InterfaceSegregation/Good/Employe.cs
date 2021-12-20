using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDLL.SOLID.InterfaceSegregation.Good
{
    public class Employe
    {
        public int Id { get; set; }
        public string Nom { get; set; }
        public DateTime DateEmbauche { get; set; }
        public string TypeContrat { get; set; }
    }
}
