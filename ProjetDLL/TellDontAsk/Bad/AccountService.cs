using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDLL.TellDontAsk.Bad
{
    public class AccountService
    {
        private AccountRepository repo;

        //Méthode de retrait

        public void Withdraw(int accountId, double amount)
        {
            Account c = repo.FindById(accountId);

            if (c.Balance < amount)
            {
                throw new Exception("Error: not enough money!");
            }
            c.Balance -= amount;
            repo.Save(c);
        }
    }
}
