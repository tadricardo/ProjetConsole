using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDLL.SOLID.SingleOfResponsability.Good
{
    public class Contact
    {
        /*
         * Classe Objet: rôle décrire la structure d'un objet de type Contact
         */
        public int Id { get; set; }
        public string Name { get; set; }

        public Contact()
        {
        }

        public Contact(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}
