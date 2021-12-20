using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetDLL.DesignPatterns.Creation.Builder
{
    public class BankAccountBuilder : BankAccount
    {
        public BankAccountBuilder WithNumber(long number)
        {
            accountNumber = number;
            return this;
        }

        public BankAccountBuilder WithNameAndPassword(string name, string password)
        {
            this.name = name;
            this.password = password;
            return this;
        }

        public BankAccountBuilder AccountIsLocked(bool locked)
        {
            isLocked = locked;
            return this;
        }

        public BankAccountBuilder WithLoan(double amount, float interestRate)
        {
            loanAmount = amount;
            this.interetRate = interestRate;
            return this;
        }

        public BankAccountBuilder AccountIsLoanInsured(bool insured)
        {
            isLoanInsured = insured;
            return this;
        }

        public BankAccountBuilder WithType(AccountType type)
        {
            accountType = type;
            return this;
        }

        public BankAccountBuilder Build()
        {
            return this;
        }
    }
}
