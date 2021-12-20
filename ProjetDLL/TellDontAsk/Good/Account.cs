using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDLL.TellDontAsk.Good
{
    public class Account
    {
        public int Id { get; set; }
        public double Balances { get; set; }

        public Account(int id, double balances)
        {
            Id = id;
            Balances = balances;
        }

        internal void Withdraw(double amount)
        {
            if (Balances < amount)
            {
                throw new Exception("Error: not enough money!");
            }
            Balances -= amount;
        }
    }
}
