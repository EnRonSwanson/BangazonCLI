using System;
using System.Collections.Generic;
using BangazonCLI.Managers;
using BangazonCLI.Models;

namespace BangazonCLI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Seed the database if none exists
            var db = new DatabaseInterface("BANGAZON_CLI_DB");
            db.RunCheckForTable();
            // db.CheckToyTable();                                  // CHANGE this to CheckForTable once Andy's SQL gets merged

            // Present the main menu
            Console.WriteLine ("*************************************************");
            Console.WriteLine ("Welcome to Bangazon! Command Line Ordering System");
            Console.WriteLine ("*************************************************");
            Console.WriteLine ("1. Create a customer account");
            Console.WriteLine ("2. Choose an active customer");
			Console.Write ("> ");

			// Read in the user's choice
			int choice;
			Int32.TryParse (Console.ReadLine(), out choice);

            // If option 1 was chosen, create a new customer account
            if (choice == 1)
            {
                Console.WriteLine ("Enter customer first name");
                Console.Write ("> ");
                string firstName = Console.ReadLine();
                Console.WriteLine ("Enter customer last name");
                Console.Write ("> ");
                string lastName = Console.ReadLine();
                Console.WriteLine ("Enter customer city");
                Console.Write ("> ");
                string city = Console.ReadLine();
                Console.WriteLine ("Enter customer state");
                Console.Write ("> ");
                string state = Console.ReadLine();
                Console.WriteLine ("Enter customer postal code");
                Console.Write ("> ");
                string postalCode = Console.ReadLine();
                Console.WriteLine ("Enter customer phone number");
                Console.Write ("> ");
                string phoneNumber = Console.ReadLine();
                // CustomerManager manager = new CustomerManager();
            }
            // Set Active Customer Menu
            // Gets a list of customers and displays them
            if(choice == 2)
            {
                CustomerManager _manager = new CustomerManager(db);
                Console.WriteLine("*************************************************");
                List<Customer> allCustomers = _manager.GetListCustomers();
                for (int i = 1; i < allCustomers.Count; i++ )
                {
                    Console.WriteLine($"{i}. {allCustomers[i-1].Name}");
                }
                Console.WriteLine("*************************************************");
                Console.WriteLine("Select a customer to be active");
                Console.Write("> ");
                
            }
        }
    }
}