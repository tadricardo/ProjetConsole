using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDLL.TellDontAsk.Bad
{
    public class Account
    {
        public int Id { get; set; }
        public double Balance { get; set; }

        public Account(int id, double balance)
        {
            Id = id;
            Balance = balance;
        }
    }
}
