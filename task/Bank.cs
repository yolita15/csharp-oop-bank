using System;
using System.Collections.Generic;

namespace task
{
    class Bank
    {
        string name;
        string address;
        List<Customer> customers = new List<Customer>();
        List<Account> accounts = new List<Account>();
        public enum accountTypes { current, savings, privilege } 

        public string Name { get => name; }
        public string Address { get => address; }

        public Bank(string name, string address)
        {
            this.name = name;
            this.address = address;
        }

        public Bank(Bank other) : this(other.name, other.address) { }

        public void addCustomer(string customerId, string name, string address)
        {
            if (customers.Count != 0)
            {
                foreach (var c in customers)
                {
                    if (c.Id == customerId)
                    {
                        Console.WriteLine("Customer with that ID already exists!");
                        break;
                    }
                }
            }

            Customer customer = new Customer(customerId, name, address);
            customers.Add(customer);
            Console.WriteLine("Successfuly added new customer!");
        }

        public void listCustomers()
        {
            if (customers.Count != 0)
            {
                customers.ForEach((customer) => customer.display());
            }
            else
            {
                Console.WriteLine("There are no customers of the bank!");
            }
            
        }

        public void deleteCustomer(string customerId)
        {
            bool notFound = true;
            if(customers.Count != 0)
            {
                foreach (var customer in customers)
                {
                    if (customer.Id == customerId)
                    {
                        customers.Remove(customer);
                        Console.WriteLine("Successfully deleted customer with ID: " + customer.Id);
                        notFound = false;
                        break;
                    }
                }
                if(notFound)
                {
                    Console.WriteLine("Custoemer not found");
                }
            }
            else
            {
                Console.WriteLine("There are no customers of the bank!");
                return;
            }

            if (accounts.Count != 0)
            {
                for (int i = 0; i < accounts.Count; i++)
                {
                    if(accounts[i].OwnerId == customerId)
                    {
                        accounts.Remove(accounts[i]);
                        --i;
                    }
                }
            }
        }

        public void addAccount(accountTypes type, string iban, string ownerId, double amount)
        {
            if (accounts.Count != 0)
            {
                foreach (var account in accounts)
                {
                    if (account.Iban == iban)
                    {
                        Console.WriteLine("Error! IBAN already exists");
                        return;
                    }
                }
            }

            if (customers.Count != 0)
            {
                bool notFound = true;
                foreach (var customer in customers)
                {
                    if (customer.Id == ownerId)
                    {
                        if (type == accountTypes.current)
                        {
                            CurrentAccount account = new CurrentAccount(iban, ownerId, amount);
                            accounts.Add(account);
                            notFound = false;
                            Console.WriteLine("Successfully added new account!");
                            break;
                        }
                        if (type == accountTypes.savings)
                        {
                            Console.WriteLine("Account type \"savings\" must have interest rate. Enter interest rate: ");
                            double interestRate = Convert.ToDouble(Console.ReadLine());

                            SavingsAccount account = new SavingsAccount(iban, ownerId, amount, interestRate);
                            accounts.Add(account);
                            notFound = false;
                            Console.WriteLine("Successfully added new account!");
                            break;
                        }
                        if (type == accountTypes.privilege)
                        {
                            Console.WriteLine("Account type \"privilege\" must have overdraft. Enter interest overdraft: ");
                            double overdraft = Convert.ToDouble(Console.ReadLine());

                            PrivilegeAccount account = new PrivilegeAccount(iban, ownerId, amount, overdraft);
                            accounts.Add(account);
                            notFound = false;
                            Console.WriteLine("Successfully added new account!");
                            break;
                        }
                        else
                        {
                            Console.WriteLine("Wrong type of account!");
                        }
                    }
                }
                if (notFound)
                {
                    Console.WriteLine("Customer not found!");
                }
            }
            else
            {
                Console.WriteLine("There are no customers of the bank!");
            }
        }

        public void listAccounts()
        {
            accounts.ForEach((account) => account.display());
        }

        public void deleteAccount(string iban)
        {
            if (accounts.Count != 0)
            {
                bool notFound = true;
                foreach (var account in accounts)
                {
                    if (account.Iban == iban)
                    {
                        accounts.Remove(account);
                        Console.WriteLine("Successfully deleted account with IBAN: " + iban);
                        notFound = false;
                        break;
                    }
                }
                if(notFound)
                {
                    Console.WriteLine("IBAN Not found!");
                }

            }
            else
            {
                Console.WriteLine("No bank accounts in the bank!");
            }
        }

        public void listCustomerAccount(string customerId)
        {
            if (accounts.Count != 0)
            {
                foreach (var account in accounts)
                {
                    if (account.OwnerId == customerId)
                    {
                        account.display();
                    }
                }
            }
            else
            {
                Console.WriteLine("No bank accounts in the bank!");
            }
        }

        public void transfer(string fromIban, string toIban, double amount)
        {
            bool transfered = false;

            if (accounts.Count != 0)
            {
                bool flag = false;
                foreach (var account in accounts)
                {
                    if (account.Iban == fromIban)
                    {
                        flag = account.withdraw(amount);
                        if (flag) break;
                    }
                }
                if (flag == false)
                {
                    Console.WriteLine("Impossible transfer!");
                }

                foreach (var account in accounts)
                {
                    if(account.Iban == toIban)
                    {
                        account.deposit(amount);
                        transfered = true;
                        Console.WriteLine("Successful transfer from account with IBAN: " + fromIban + " to account with IBAN: " + toIban);
                        break;
                    }
                }

                if(transfered == false)
                {
                    Console.WriteLine("Unsuccessful transfer!");

                    foreach (var account in accounts)
                    {
                        if (account.Iban == fromIban)
                        {
                            account.deposit(amount);
                        }
                    }
                }
            }
            else
            {
                Console.WriteLine("No bank accounts in the bank!");
            }
        }
        public void withdrawFromAccount(string iban, double amount)
        {
            bool notFound = false;
            bool success = false;
            if (accounts.Count != 0)
            {
                foreach (var account in accounts)
                {
                    if (account.Iban == iban)
                    {
                        success = account.withdraw(amount);
                        notFound = false;
                    }
                }
                if (success)
                {
                    Console.WriteLine("Successful withdraw!");
                }
                if (notFound)
                {
                    Console.WriteLine("IBAN Not Found!");
                }
            }
            else
            {
                Console.WriteLine("No bank accounts in the bank!");
            }
            
        }

        public void depositToAccount (string iban, double amount)
        {
            bool notFound = true;
            foreach (var account in accounts)
            {
                if (account.Iban == iban)
                {
                    account.deposit(amount);
                    notFound = false;
                    Console.WriteLine("Successful deposit!");
                    break;
                }
            }
            if (notFound)
            {
                Console.WriteLine("IBAN Not Found!");
            }
        }
        public void display()
        {
            Console.WriteLine("Bank Name: " + Name);
            Console.WriteLine("Bank Address: " + Address);
            Console.WriteLine("Number accounts in the bank: " + accounts.Count);
            Console.WriteLine("Number customers of the bank: " + customers.Count);
        }
    }
}
