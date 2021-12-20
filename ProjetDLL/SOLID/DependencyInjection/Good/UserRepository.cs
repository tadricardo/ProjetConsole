using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDLL.SOLID.DependencyInjection.Good
{
    public class UserRepository : IUserRepository
    {
        public User GetById(int id)
        {
            //Bases de données
            return null;
        }
    }
}
