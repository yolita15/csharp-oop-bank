namespace task
{
    abstract class Account
    {
        string iban;
        string ownerId;
        double amount;
        public string Iban { get => iban; }
        public string OwnerId { get => ownerId; }
        public Account(string iban, string ownerId, double amount)
        {
            this.iban = iban;
            this.ownerId = ownerId;
            this.amount = amount;
        }

        public Account(Account other) : this(other.iban, other.ownerId, other.amount) { }

        public double getBalance() => amount;     

        abstract public void deposit(double amount);

        abstract public bool withdraw(double amount);

        abstract public void display();

        protected void addAmount(double amount)
        {
            this.amount += amount;
        }
        
        protected void removeAmount(double amount)
        {
            this.amount -= amount;
        }
    }
}
