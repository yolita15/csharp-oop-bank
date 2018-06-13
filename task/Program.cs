using System;
using System.Collections.Generic;

namespace task
{
    class Program
    {
        public static void menu()
        {
            Console.WriteLine("1.  List customers");
            Console.WriteLine("2.  Add new customer");
            Console.WriteLine("3.  Delete customer");
            Console.WriteLine("4.  List all accounts");
            Console.WriteLine("5.  List customer accounts");
            Console.WriteLine("6.  Add new account");
            Console.WriteLine("7.  Delete account");
            Console.WriteLine("8.  Withdraw from account");
            Console.WriteLine("9.  Deposit to account");
            Console.WriteLine("10. Transfer");
            Console.WriteLine("11. Display info for the bank");
            Console.WriteLine("12. Quit");
        }
        static void Main()
        {
            Bank bank = new Bank("UnicreditBulbank", "G.S Rakovski");
            
            menu();
            Console.WriteLine( "Enter your choice: ");
            int choice;
            choice = Convert.ToInt32(Console.ReadLine());

            while (true)
            {
                if (choice == 1)
                {
                    bank.listCustomers();
                }
                else if (choice == 2)
                {
                    Console.WriteLine("Enter customer ID: ");
                    string customerId = Console.ReadLine();
                    Console.WriteLine("Enter customer name: ");
                    string name = Console.ReadLine();
                    Console.WriteLine("Enter customer address: ");
                    string address = Console.ReadLine();

                    bank.addCustomer(customerId, name, address);
                }
                else if (choice == 3)
                {
                    Console.WriteLine("Enter customer ID: ");
                    string customerId = Console.ReadLine();

                    bank.deleteCustomer(customerId);
                }
                else if (choice == 4)
                {
                    bank.listAccounts();
                }
                else if (choice == 5)
                {
                    Console.WriteLine("Enter customer ID: ");
                    string customerId = Console.ReadLine();

                    bank.listCustomerAccount(customerId);
                }
                else if (choice == 6)
                {
                    Console.WriteLine("Choose type of account: ");
                    Console.WriteLine("A: Current Account");
                    Console.WriteLine("B: Savings Account");
                    Console.WriteLine("C: Privilege Account");
                    string type = Console.ReadLine();

                    if (type == "A")
                    {
                        Console.WriteLine("Enter IBAN: ");
                        string iban = Console.ReadLine();
                        Console.WriteLine("Enter owner ID: ");
                        string ownerId = Console.ReadLine();
                        Console.WriteLine("Enter amount: ");
                        double amount = Convert.ToDouble(Console.ReadLine());

                        bank.addAccount(Bank.accountTypes.current, iban, ownerId, amount);
                    }
                    else if (type == "B")
                    {
                        Console.WriteLine("Enter IBAN: ");
                        string iban = Console.ReadLine();
                        Console.WriteLine("Enter owner ID: ");
                        string ownerId = Console.ReadLine();
                        Console.WriteLine("Enter amount: ");
                        double amount = Convert.ToDouble(Console.ReadLine());

                        bank.addAccount(Bank.accountTypes.savings, iban, ownerId, amount);
                    }
                    else if (type == "C")
                    {
                        Console.WriteLine("Enter IBAN: ");
                        string iban = Console.ReadLine();
                        Console.WriteLine("Enter owner ID: ");
                        string ownerId = Console.ReadLine();
                        Console.WriteLine("Enter amount: ");
                        double amount = Convert.ToDouble(Console.ReadLine());

                        bank.addAccount(Bank.accountTypes.privilege, iban, ownerId, amount);
                    }
                    else
                    {
                        Console.WriteLine("Wrong choice!");
                    }
                }
                else if (choice == 7)
                {
                    Console.WriteLine("Enter IBAN: ");
                    string iban = Console.ReadLine();
                    bank.deleteAccount(iban);
                }
                else if (choice == 8)
                {
                    Console.WriteLine("Enter IBAN: ");
                    string iban = Console.ReadLine();
                    Console.WriteLine("Enter amount: ");
                    double amount = Convert.ToDouble(Console.ReadLine());

                    bank.withdrawFromAccount(iban, amount);
                }
                else if (choice == 9)
                {
                    Console.WriteLine("Enter IBAN: ");
                    string iban = Console.ReadLine();
                    Console.WriteLine("Enter amount: ");
                    double amount = Convert.ToDouble(Console.ReadLine());

                    bank.depositToAccount(iban, amount);
                }
                else if (choice == 10)
                {
                    Console.WriteLine("Enter IBAN you want to transfer from: ");
                    string ibanFrom = Console.ReadLine();
                    Console.WriteLine("Enter IBAN you want to tranfer to: ");
                    string ibanTo = Console.ReadLine();
                    Console.WriteLine("Enter amount: ");
                    double amount = Convert.ToDouble(Console.ReadLine());

                    bank.transfer(ibanFrom, ibanTo, amount);
                }
                else if (choice == 11)
                {
                    bank.display();
                }
                else if (choice == 12)
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong choice!");
                }

                Console.ReadKey();
                Console.Clear();
                menu();
                Console.WriteLine("Enter your choice: ");
                choice = Convert.ToInt32(Console.ReadLine());

            }
        }
    }
}
