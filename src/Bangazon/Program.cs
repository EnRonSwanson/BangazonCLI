using System;
using System.Collections.Generic;
using System.Linq;
using BangazonCLI.Managers;
using BangazonCLI.Models;

// Method authors listed above each
// Program loop and org by Mitchell
// These are menu options for user experience

namespace BangazonCLI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var db = new DatabaseInterface("BANGAZON_CLI_DB");
            ActiveCustomer activeCustomer = new ActiveCustomer();
            ProductManager productManager = new ProductManager(db);
            // Seed the database if none exists
            db.RunCheckForTable();
                                  // CHANGE this to CheckForTable once Andy's SQL gets merged
            CustomerManager manager = new CustomerManager(db);

            // Read in the user's choice
            int choice;

            do {

                // Present the main menu
                Console.WriteLine ("*************************************************");
                Console.WriteLine ("Welcome to Bangazon! Command Line Ordering System");
                Console.WriteLine ("*************************************************");
                Console.WriteLine ("1. Create a customer account");
                Console.WriteLine ("2. Choose an active customer");
                Console.WriteLine ("4. Add product to sell");
                Console.WriteLine ("12. Leave Bangazon!");
                Console.Write ("> ");
                Int32.TryParse (Console.ReadLine(), out choice);

                // If option 1 was chosen, create a new customer account
                // Written by Ryan
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
                    Console.WriteLine ("Enter customer street address");
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
                // Set Active Customer Menu
                // Written by Andy and Mitchell
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
                    string setThisCustomerAsActive = Console.ReadLine();
                    activeCustomer.setActiveCustomerId(setThisCustomerAsActive);
                }
                // If option 4 was chosen, create a new product for the logged in user
                // Written by Mitchell
                if (choice == 4)
                {   
                    // product id is auto generated
                    Console.WriteLine ("Enter product title");
                    Console.Write ("> ");
                    string Title = Console.ReadLine();
                    // maybe eventually the user will choose product type from list of product types, or add new
                    Console.WriteLine ("Enter product type");
                    Console.Write ("> ");
                    string Type = "1";                                     // this might need to be user selection from product types
                    Console.WriteLine ("Enter product description");
                    Console.Write ("> ");
                    string Description = Console.ReadLine();
                    Console.WriteLine ("Enter price");
                    Console.Write ("> ");
                    string Price = Console.ReadLine();
                    Console.WriteLine ("Enter quantity available");
                    Console.Write ("> ");
                    string QuantityAvailable = Console.ReadLine();
                    string SellerId = activeCustomer.getActiveCustomerId();         // customer id calls getter for active customer
                    int newProductId = productManager.CreateProduct(new Product(Int32.Parse(Type), Title, Int32.Parse(QuantityAvailable), Description, float.Parse(Price), Int32.Parse(SellerId)));
                }
            } while (choice != 12);
        }
    }
}   