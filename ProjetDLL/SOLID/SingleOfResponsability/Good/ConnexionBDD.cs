using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDLL.SOLID.SingleOfResponsability.Good
{
    public class ConnexionBDD
    {
        //Gérer la connexion à la BD
        public static SqlConnection GetConnexion()
        {
            SqlConnection cnx = new SqlConnection("chaine");
            cnx.Open();
            return cnx;
        }
    }
}
