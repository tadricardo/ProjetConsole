using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDLL.DesignPatterns.Structure.Adapter
{
    public interface IContactRepository
    {
        string FindXmlContacts(string path);
        List<Contact> FromString(string xml);
    }
}
