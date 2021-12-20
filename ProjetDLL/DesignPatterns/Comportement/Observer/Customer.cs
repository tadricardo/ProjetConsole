using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDLL.DesignPatterns.Comportement.Observer
{
    public class Customer : IObserver
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }

        public Customer(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public void Update(ISujet sujet)
        {
            ProductItem p = (ProductItem)sujet;
            string emailBody = "Bonjour,\n le prix du produit à été modifié: "+p.Price;

            MailMessage message = new MailMessage("noreplay@dawn.fr",Email, p.Description, emailBody);
    

            SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
            client.UseDefaultCredentials = true;
            client.Credentials = new NetworkCredential("username", "password");
            client.EnableSsl = true;
            client.Send(message);
        }
    }
}
