using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace task
{
    class CurrentAccount : Account
    {
        public CurrentAccount(string iban, string ownerId, double amount) : base(iban, ownerId, amount) { }

        public CurrentAccount(CurrentAccount other) : base(other) { }

        public override void deposit(double amount)
        {
            addAmount(amount);
        }

        public override bool withdraw(double amount)
        {
            if (amount > getBalance())
            {
                return false;
            }
            else
            {
                removeAmount(amount);
                return true;
            }
        }

        public override void display()
        {
            Console.WriteLine("Type of account: Current Account");
            Console.WriteLine("IBAN: " + Iban);
            Console.WriteLine("Owner ID: " + OwnerId);
            Console.WriteLine("Balance: " + getBalance());
        }
    }
}
