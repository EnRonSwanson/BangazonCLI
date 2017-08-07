using System;
using System.Linq;
using BangazonCLI.Managers;
using BangazonCLI.Models;

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

            // Present the main menu
            Console.WriteLine ("*************************************************");
            Console.WriteLine ("Welcome to Bangazon! Command Line Ordering System");
            Console.WriteLine ("*************************************************");
            Console.WriteLine ("1. Create a customer account");
            Console.WriteLine ("4. Add product to sell");
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
            // If option 4 was chosen, create a new product for the logged in user
            // Written by Mitchell
            if (choice == 4)
            {   
                // product id is auto generated
                Console.WriteLine ("Enter product title");
                Console.Write ("> ");
                string Title = Console.ReadLine();
                // eventually the user will product type from list of product types, or add new
                Console.WriteLine ("Enter product type");
                Console.Write ("> ");
                string Type = "1";                                     // this will need to be user selection from product types
                Console.WriteLine ("Enter product description");
                Console.Write ("> ");
                string Description = Console.ReadLine();
                Console.WriteLine ("Enter price");
                Console.Write ("> ");
                string Price = Console.ReadLine();
                Console.WriteLine ("Enter quantity available");
                Console.Write ("> ");
                string QuantityAvailable = Console.ReadLine();
                // int? customerId = activeCustomer.getActiveCustomerId();         // customer id calls getter for active customer
                string SellerId = "1";                                             // this needs changing after testing

                int newProductId = productManager.CreateProduct(new Product(Int32.Parse(Type), Title, Int32.Parse(QuantityAvailable), Description, float.Parse(Price), Int32.Parse(SellerId)));
            }
        }
  }
}   