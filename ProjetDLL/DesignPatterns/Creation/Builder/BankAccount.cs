using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDLL.DesignPatterns.Creation.Builder
{
    public enum AccountType
    {
        COURANT,
        EPARGNE,
        PRO,
        LIVRET_A
    }

    public class BankAccount
    {
        public long accountNumber;
        public string name;
        public string password;
        public bool isLocked;
        public double loanAmount;
        public bool isLoanInsured;
        public float interetRate;
        public AccountType accountType;

        

        //public BankAccount(long accountNumber, string name, string password, bool isLocked, double loanAmount, bool isLoanInsured, float interetRate)
        //{
        //    this.accountNumber = accountNumber;
        //    this.name = name;
        //    this.password = password;
        //    this.isLocked = isLocked;
        //    this.loanAmount = loanAmount;
        //    this.isLoanInsured = isLoanInsured;
        //    this.interetRate = interetRate;
        //}

        //public BankAccount(long accountNumber, string name, string password, bool isLocked)
        //{
        //    this.accountNumber = accountNumber;
        //    this.name = name;
        //    this.password = password;
        //    this.isLocked = isLocked;
        //}

        //public BankAccount(long accountNumber, bool isLocked)
        //{
        //    this.accountNumber = accountNumber;
        //    this.isLocked = isLocked;
        //}

        //public BankAccount()
        //{
        //}
    }
}
