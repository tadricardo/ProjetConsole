using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDLL.TellDontAsk.Good
{
    public class AccountService
    {
        private IAccountRepository repo;

        //Méthode de retrait
        public void Withdraw(int accountId, double amount)
        {
            Account c = repo.FindById(accountId);

            //Tell d'ont ask: dire à l'objet ce qu'il doit faire
            c.Withdraw(amount);
            repo.Save(c);
        }
    }
}
