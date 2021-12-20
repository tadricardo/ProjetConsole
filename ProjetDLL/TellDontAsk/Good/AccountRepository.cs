using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDLL.TellDontAsk.Good
{
    public class AccountRepository : IAccountRepository
    {
        public Account FindById(int id)
        {
            return null;
        }

        public void Save(Account c)
        {
            //save en BD
        }
    }
}
