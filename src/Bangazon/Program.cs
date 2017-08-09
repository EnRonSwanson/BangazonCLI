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
            PaymentTypeManager payment= new PaymentTypeManager(db);
            OrderManager orderManager = new OrderManager(db);
            // Seed the database if none exists
            db.RunCheckForTable();
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
                Console.WriteLine ("3. Create a payment type");
                Console.WriteLine ("4. Add product to sell");
                Console.WriteLine ("5. Add Product to Shopping Cart");
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
                    int custId= manager.AddCustomer(new Customer(fullName, street, city, state, Int32.Parse(postalCode), phoneNumber));
                }
                // Set Active Customer Menu
                // Written by Ryan, Andy, and Mitchell
                // Gets a list of customers and displays them
                if(choice == 2)
                {
                    CustomerManager _manager = new CustomerManager(db);
                    Console.WriteLine("*************************************************");
                    List<Customer> allCustomers = _manager.GetListCustomers();
                    for (int i = 0; i < allCustomers.Count; i++ )
                    {
                        Console.WriteLine($"{i+1}. {allCustomers[i].Name}");
                    }
                    Console.WriteLine("*************************************************");
                    Console.WriteLine("Select a customer to be active");
                    Console.Write("> ");
                    string setThisCustomerAsActive = Console.ReadLine();
                    activeCustomer.setActiveCustomerId(Int32.Parse(setThisCustomerAsActive));
                    var active= ActiveCustomer.activeCustomerId;
                    // potential getter to convert customer ID to its corresponding name
                    Console.WriteLine("Active customer ID is: " + active);
                }
                if (choice ==3)
                {
                    Console.WriteLine("Enter a payment type (visa, mastercard, etc)");
                    Console.Write("> ");
                    string paymentType= Console.ReadLine();
                    Console.WriteLine("Enter the account # associated with your payment type");
                    Console.Write("> ");
                    string accountNum= Console.ReadLine();
                    int customerId = ActiveCustomer.activeCustomerId;
                    int paymentId= payment.CreatePaymentType(new PaymentType(customerId ,paymentType, accountNum));

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
                    
                // manually add product type
                    Console.WriteLine ("Enter product type");
                    Console.Write ("> ");
                    // string Type = "1";                                     // this might need to be user selection from product types
                    
                // choose from list of existing product types
                    ProductTypeManager _manager = new ProductTypeManager(db);
                    Console.WriteLine("*************************************************");
                    List<ProductType> allProductTypes = _manager.GetListProductTypes();
                    for (int i = 0; i < allProductTypes.Count; i++ )
                    {
                        Console.WriteLine($"{i+1}. {allProductTypes[i].Type}");
                    }
                    Console.WriteLine("*************************************************");
                    Console.WriteLine("Select an existing product type by number OR enter a new type");
                    Console.Write("> ");
                    int TypeId = 0;
                    string enteredProductType = Console.ReadLine();
                    if (Int32.TryParse(enteredProductType, out TypeId)) {
                    } else {
                        ProductType newProductType = new ProductType(enteredProductType);
                        TypeId = _manager.AddProductType(newProductType);
                    }
                    var active= ActiveCustomer.activeCustomerId;
                    Console.WriteLine ("Enter product description");
                    Console.Write ("> ");
                    string Description = Console.ReadLine();
                    Console.WriteLine ("Enter price");
                    Console.Write ("> ");
                    string Price = Console.ReadLine();
                    Console.WriteLine ("Enter quantity available");
                    Console.Write ("> ");
                    string QuantityAvailable = Console.ReadLine();
                    int SellerId = ActiveCustomer.activeCustomerId;         // customer id calls getter for active customer
                    int newProductId = productManager.CreateProduct(new Product(TypeId, Title, Int32.Parse(QuantityAvailable), Description, float.Parse(Price), SellerId));
                }
             
                if (choice == 5)
                {
                    Console.WriteLine("*********************");
                    List<Product> productList = productManager.GetListOfProducts();

                    int? activeOrder = orderManager.CreateOrder();
                    if(activeOrder != null)
                    {
                        Console.WriteLine("This Customer already has an open order.");
                    }
                    else{
                        Console.WriteLine("Created a new order for the customer");
                    }
                    Console.WriteLine("What product would you like to add?");
                    int counter = 1;
                    foreach(Product product in productList)
                    {
                        Console.WriteLine($"{counter}. {product.Title}");
                        counter ++;
                    
                    }
                    Console.Write("> ");
                    string productChoice = Console.ReadLine();
                    int productChoiceNum = Int32.Parse(productChoice);
                    int? addedProductId = productList[productChoiceNum-1].ProductId;

                    orderManager.AddProductToOrder((int)addedProductId, (int)activeOrder);
                    Console.WriteLine("Product Successfully Added.");
                }
            }while (choice != 12);
        }
    }
}   