using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDLL.SOLID.DependencyInjection.Bad
{
    public class UserService
    {

        //Méthode qui applique un traitement pour un user
        public object TraiterUser(int id)
        {
            UserRepository repo = new UserRepository();
            User u = repo.GetById(id);

            //Appliquer un traitement au user
            return null;
        }

        //Méthode complètement dépendante de UserRepository - Code sans injection de dépendence
    }
}
