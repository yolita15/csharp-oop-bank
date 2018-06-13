using System;

namespace task
{
    class Customer
    {
        string id;
        string name;
        string address;

        public Customer(string id, string name, string address)
        {
            this.id = id;
            this.name = name;
            this.address = address;
        }

        public Customer(Customer other) : this(other.id, other.name, other.address) { }

        public string Id { get => id; }
        
        public string Name { get => name; }

        public string Address { get => address; }

        public void display ()
        {
            Console.WriteLine("Customer ID: " + Id);
            Console.WriteLine("Customer Name: " + Name);
            Console.WriteLine("Customer Address: " + Address);
        }
    }
}
