using System;
using System.Collections.Generic;
using System.Linq;
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
                                       // CHANGE this to CheckForTable once Andy's SQL gets merged
            CustomerManager manager = new CustomerManager(db);
            // Present the main menu
            Console.WriteLine ("*************************************************");
            Console.WriteLine ("Welcome to Bangazon! Command Line Ordering System");
            Console.WriteLine ("*************************************************");
            Console.WriteLine ("1. Create a customer account");
            Console.WriteLine ("2. View available customers");
			Console.Write ("> ");

			// Read in the user's choice
			int choice;
			Int32.TryParse (Console.ReadLine(), out choice);

            // If option 1 was chosen, create a new customer account
            if (choice == 1)
            {
                Console.WriteLine ("Enter customer full name");
                Console.Write ("> ");
                string fullName = Console.ReadLine();
                Console.WriteLine ("Enter customer city");
                Console.Write ("> ");
                string city = Console.ReadLine();
                Console.WriteLine ("Enter customer state");
                Console.Write ("> ");
                string state = Console.ReadLine();
                Console.WriteLine ("Enter customer street adress");
                Console.Write ("> ");
                string street = Console.ReadLine();
                Console.WriteLine ("Enter customer postal code");
                Console.Write ("> ");
                string postalCode = Console.ReadLine();
                Console.WriteLine ("Enter customer phone number");
                Console.Write ("> ");
                string phoneNumber = Console.ReadLine();   

                int custId= manager.AddCustomer(new Customer(fullName, street,city, state, postalCode, phoneNumber));
            }
            if (choice == 2)
            {
                Console.WriteLine("All available customers");
                List<Customer> custList= new List<Customer>();
                custList= manager.getListCustomers();
            }
        }
    }
}