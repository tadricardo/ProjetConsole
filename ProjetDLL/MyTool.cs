using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDLL
{
    public static class MyTool
    {
        /*Pour définir une méthode d'extension:
         * 1- Définir la classe static
         * 2- Dans les paramétres de la méthode, appliquer le mot clé this sur la classe à etendre
         * 
         */
        public static string ChangerPremierChar(this string chaine)
        {
            char[] tab = chaine.ToArray();
            if (char.IsUpper(tab[0]))
            {
                tab[0] = char.ToLower(tab[0]);
            }
            else
            {
                tab[0] = char.ToUpper(tab[0]);
            }

            return new string(tab);
        }
    }
}
