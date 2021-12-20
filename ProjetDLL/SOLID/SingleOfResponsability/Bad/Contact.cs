using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDLL.SOLID.SingleOfResponsability.Bad
{
    public class Contact
    {
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

        public void Save(Contact c)
        {
            SqlConnection cnx = new SqlConnection();
            string sql = "INSERT INTO Contacts(id,name)VALUES('"+c.Id+"','"+c.Name+"')";
            SqlCommand cmd = new SqlCommand(sql, cnx);
            cmd.ExecuteNonQuery();
            cnx.Close();
        }
        /*
         * Responsabilités de la classe:
         * - Création d'objets Contact
         * - Connexion à la BD
         * - Persistence des objets Contact
         * 
         */
    }
}
