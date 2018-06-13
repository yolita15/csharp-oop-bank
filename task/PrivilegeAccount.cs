using System;

namespace task
{
    class PrivilegeAccount : Account
    {
        double overdraft;
        public double Overdraft { get => overdraft; }

        public PrivilegeAccount(string iban, string ownerId, double amount, double overdraft) : base(iban, ownerId, amount)
            => this.overdraft = overdraft;

        public PrivilegeAccount(PrivilegeAccount other) : base(other) => overdraft = other.overdraft;

        public override void deposit(double amount) => addAmount(amount);

        public override bool withdraw(double amount)
        {
            double currentAmount = getBalance() + Overdraft;
            if (amount > currentAmount)
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
            Console.WriteLine("Overdraft: " + Overdraft);
            Console.WriteLine("Balance: " + getBalance());
        }

    }
}
