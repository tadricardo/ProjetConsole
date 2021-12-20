using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDLL.SOLID.SingleOfResponsability.Good
{
    public class ContactRepository
    {
        //Rôle: gérer la persistence des objets de type Contact
        public void Save(Contact c)
        {
            SqlConnection cnx = ConnexionBDD.GetConnexion();
            string sql = "INSERT INTO Contacts(id,name)VALUES('" + c.Id + "','" + c.Name + "')";
            SqlCommand cmd = new SqlCommand(sql, cnx);
            cmd.ExecuteNonQuery();
            cnx.Close();
        }
    }
}
