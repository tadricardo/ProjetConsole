using ProjetDLL.Genericite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDLL.DesignPatterns.Structure.Adapter
{
    public class JsonAdapter : IJsonAdapter
    {
        private IContactRepository xmlRepo;

        public JsonAdapter(IContactRepository xmlRepo)
        {
            this.xmlRepo = xmlRepo;
        }

        public string FindJsonContacts(string path)
        {
            string xml = xmlRepo.FindXmlContacts(path);

            //Transformer le contenu xml en JSON
            List<Contact> lst = xmlRepo.FromString(xml);

            return JsonTool.ToJson(lst);
        }
    }
}
