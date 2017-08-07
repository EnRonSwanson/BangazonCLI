using System;

namespace BangazonCLI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            // Seed the database if none exists
            var db = new DatabaseInterface("BANGAZON_CLI_DB");
            db.RunCheckForTable();

            // Present the main menu
            Console.WriteLine ("*************************************************");
            Console.WriteLine ("Welcome to Bangazon! Command Line Ordering System");
            Console.WriteLine ("*************************************************");
            Console.WriteLine ("1. Create a customer account");
			Console.Write ("> ");
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
            if (choice == 4)
            {
                // product id is auto generated
                Console.WriteLine ("Enter product title");
                Console.Write ("> ");
                string Title = Console.ReadLine();
                // product type from list of product types, or add new
                Console.WriteLine ("Enter product description");
                Console.Write ("> ");
                string Description = Console.ReadLine();
                Console.WriteLine ("Enter price");
                Console.Write ("> ");
                string Price = Console.ReadLine();
                Console.WriteLine ("Enter quantity available");
                Console.Write ("> ");
                string QuantityAvailable = Console.ReadLine();
                // customer id calls getter for active customer



            }
        }
    }
}