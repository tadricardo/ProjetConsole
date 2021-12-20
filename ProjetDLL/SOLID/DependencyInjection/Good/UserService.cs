using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDLL.SOLID.DependencyInjection.Good
{
    public class UserService
    {
        //Mise en évidence de la dépendence
        private IUserRepository repo;

        //Cas1: injection par consctruteur
        //Avantage:
        //on obtient un objet service dans un état stable - toutes les dépendences sont initialisées
        //Incovenient: impossible de changer de dépendence
        public UserService(IUserRepository repo)
        {
            this.repo = repo;
        }


        public object TraiterUser(int id)
        {
            User u = repo.GetById(id);

            //Traiter User
            return null;
        }

        //Cas2: injection de dépendence via les paramétre de la méthode
        //Avantage: a chaque appel de la méthode on a la possibilité de faire varier la dépendence
        //Inconvénient: contrainte - Dépendence à fournir à achque appel de la méthode

        public object TraiterUser(int id, IUserRepository repo)
        {
            User u = repo.GetById(id);
            //Traiter user
            return null;
        }

        //Cas3: injection par mutateur (setteur)
        //Avantage: dépendence modifiable à tout moment
        //Incovénient: s'assurer que la dépendence à bien été injectée
        //Usage: lorsqu'on est contraint

        public IUserRepository repository
        {
            get
            {
                return repository;
            }
            set
            {
                repository = value;
            }
        }
    }
}
