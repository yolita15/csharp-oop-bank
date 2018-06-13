using System;

namespace task
{
    class SavingsAccount : Account
    {
        double interestRate;
        public double InterestRate { get => interestRate; }

        public SavingsAccount(string iban, string ownerId, double amount, double interestRate) : base(iban, ownerId, amount) 
           => this.interestRate = interestRate;
        
        public SavingsAccount(SavingsAccount other) : base(other) => interestRate = other.interestRate;
       
        public override void deposit(double amount) => addAmount(amount);
        
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
            Console.WriteLine("Interest Rate: " + InterestRate + " %");
            Console.WriteLine("Balance: " + getBalance());
        }

    }
}
