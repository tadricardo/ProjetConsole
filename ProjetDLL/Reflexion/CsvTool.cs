using ProjetDLL.Genericite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDLL.Reflexion
{
    public class CsvTool
    {
        //Méthode générique pour sauvegarder une liste d'objets sous format CSV
        public static void ToCsv<T>(List<T> list, string chemin)
        {
            StreamWriter sw = new StreamWriter(chemin);
            foreach (T obj in list)
            {
                //Récupérer les propriétés de obj de type T
                PropertyInfo[] props = obj.GetType().GetProperties(); //Ex: Product {PC Dell, 1500} - prop1;prop2
                string ligne = "";
                foreach (var prop in props)
                {
                    //Construire la ligne à insérer
                    ligne += prop.GetValue(obj) + ";";
                }
                //Insérer la ligne en supprimant le dernier char (;)
                sw.WriteLine(ligne.Substring(0, ligne.Length - 1));
            }
            sw.Close();
        }

        //Méthode générique pour restaurer la liste d'objets à partir du fichier CSV
        public static List<T> FromCsv<T>(string chemin)
        {
            List<T> lst = new List<T>();
            Type type = typeof(T);
            PropertyInfo[] props = type.GetProperties();

            if (File.Exists(chemin))
            {
                StreamReader sr = new StreamReader(chemin);
                while (!sr.EndOfStream)
                {
                    string ligne = sr.ReadLine();
                    if (ligne != null)
                    {
                        string[] tab = ligne.Split(';');
                        T obj = (T)Activator.CreateInstance(type);
                        for (int i = 0; i < tab.Length; i++)
                        {
                            props[i].SetValue(obj, Convert.ChangeType(tab[i],props[i].PropertyType));
                        }
                        lst.Add(obj);
                        
                    }
                }


                sr.Close();
            }
            else
            {
                throw new Exception("Fichier introuvable......");
            }

            return lst;
        }
    }
}
