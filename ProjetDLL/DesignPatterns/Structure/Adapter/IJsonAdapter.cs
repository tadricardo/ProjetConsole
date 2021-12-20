using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDLL.DesignPatterns.Structure.Adapter
{
    public interface IJsonAdapter
    {
        string FindJsonContacts(string path);
    }
}
