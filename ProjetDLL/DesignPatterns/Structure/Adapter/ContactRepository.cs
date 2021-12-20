using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace ProjetDLL.DesignPatterns.Structure.Adapter
{
    public class ContactRepository : IContactRepository
    {
        public string FindXmlContacts(string path)
        {
            string result = null;
            using (var sr = new StreamReader(path))
            {
                result = sr.ReadToEnd();
            }

            return result; //<Contacts><Contact><Name>hjfhgjfhf
        }

        public List<Contact> FromString(string xml)
        {
            List<Contact> lst = new List<Contact>();
            XmlDocument doc = new XmlDocument();
            doc.LoadXml(xml);

           XmlNodeList nodes = doc.DocumentElement.SelectNodes("/Contacts/Contact");
            foreach (XmlNode node in nodes)
            {
                Contact c = new Contact();
                c.Id = Convert.ToInt32(node.Attributes["id"].Value);
                c.Name = node.ChildNodes[0].InnerText;
                lst.Add(c);
            }


            return lst;
        }
    }
}
