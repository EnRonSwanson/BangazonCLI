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
            // Seeds the database if none exists
            db.RunCheckForTable();
            DBInitializer.Initialize(db);
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
                Console.WriteLine ("6. Complete an order");
                Console.WriteLine ("7. Remove customer product");
                Console.WriteLine ("8. Update product information");
                Console.WriteLine ("9. Get Revenue Report for customer");
                Console.WriteLine ("12. Leave Bangazon!");
                Console.Write ("> ");
                Int32.TryParse (Console.ReadLine(), out choice);

                // Add New Customer
                // If option 1 was chosen, create a new customer account
                // By Ryan
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
                        int custId = manager.AddCustomer(new Customer(fullName, street, city, state, Int32.Parse(postalCode), phoneNumber));
                    }
                // Set Active Customer Menu
                // By Ryan and Mitchell
                // If option 2 chosen, gets and displays list of customers - user chooses which to set as active
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
                        var active = ActiveCustomer.activeCustomerId;
                        // potential getter will go here to convert customer ID to its corresponding name
                        Console.WriteLine("Active customer ID is: " + active);
                    }
                // If option 3 was chosen, enter payment type for active customer
                // By Ryan
                if (choice == 3)
                    {
                        Console.WriteLine("Enter a payment type (visa, mastercard, etc)");
                        Console.Write("> ");
                        string paymentType= Console.ReadLine();
                        Console.WriteLine("Enter the account # associated with your payment type");
                        Console.Write("> ");
                        string accountNum= Console.ReadLine();
                        int customerId = ActiveCustomer.activeCustomerId;
                        int paymentId = payment.CreatePaymentType(new PaymentType(customerId ,paymentType, accountNum));
                    }
                // If option 4 was chosen, create a new product for the logged in user
                // By Mitchell
                if (choice == 4)
                    {   
                        // product id is auto generated
                        Console.WriteLine ("Enter product title");
                        Console.Write ("> ");
                        string Title = Console.ReadLine();
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
                        var active = ActiveCustomer.activeCustomerId;
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

                //Adding a product to an order
                //Written by Andrew Rock
                //Checks if a customer already has an open order (if not it creates a new order)
                //Then displays a list of products to add to the open order

                if (choice == 5)
                    {
                        Console.WriteLine("*********************");
                        List<Product> productList = productManager.GetListOfProducts();
                        int? activeOrder = orderManager.CreateOrder();
                        if(activeOrder != null)
                        {
                            Console.WriteLine("This Customer already has an open order.");
                        }
                        else {
                            Console.WriteLine("Created a new order for the customer");
                        }
                        Console.WriteLine("What product would you like to add?");
                        int productChoiceNum;
                        do {
                            int counter = 1;
                            foreach (Product product in productList)
                            {
                                Console.WriteLine($"{counter}. {product.Title}");
                                counter ++;
                            }
                            Console.WriteLine("99. Exit to main menu");
                            Console.Write("> ");
                            string productChoice = Console.ReadLine();
                            productChoiceNum = Int32.Parse(productChoice);
                            if(productChoiceNum != 99)
                            {
                                int? addedProductId = productList[productChoiceNum-1].ProductId;
                                orderManager.AddProductToOrder((int)addedProductId, (int)activeOrder);
                                Console.WriteLine("Product Successfully Added.");
                            }

                        } while(productChoiceNum != 99);


                    }
                // If option 8 was chosen, edit an existing product
                // By Mitchell
                if (choice == 8)
                    {
                        // gets list of product belonging to that customer
                        var active = ActiveCustomer.activeCustomerId;
                        List<Product> productList = productManager.getCustomersProducts(active);
                        for (int i = 0; i < productList.Count; i++ )
                        {
                            Console.WriteLine($"{productList[i].ProductId}. {productList[i].Title}");
                        }
                        Console.WriteLine("*************************************************");
                        Console.WriteLine("Select which of your products to edit");
                        Console.Write("> ");
                        string productIdToEdit = Console.ReadLine();
                        // passes selected product id into getter to get product details
                        Product productToEdit = productManager.getSingleProduct(Int32.Parse(productIdToEdit));
                        Console.Write("> ");
                        Console.WriteLine("Choose which field to edit");
                        Console.WriteLine ($"1. Title: {productToEdit.Title}");
                        Console.WriteLine ($"2. Description: {productToEdit.Description}");
                        Console.WriteLine ($"3. Price: {productToEdit.Price}");
                        Console.WriteLine ($"4. Quantity Available: {productToEdit.QuantityAvailable}");
                        Console.Write ("> ");
                        int fieldToEdit;
                        Int32.TryParse (Console.ReadLine(), out fieldToEdit);
                        string columnToEdit = "";
                        string newValue = "";
                        switch (fieldToEdit)
                        {
                            case 1:
                                columnToEdit = "Title";
                                Console.WriteLine ($"Enter new product title");
                                Console.Write ("> ");
                                newValue = Console.ReadLine();
                                break;
                            case 2:
                                columnToEdit = "Description";
                                Console.WriteLine ($"Enter new product description");
                                Console.Write ("> ");
                                newValue = Console.ReadLine();
                                break;
                            case 3:
                                columnToEdit = "Price";
                                Console.WriteLine ($"Enter new product price");
                                Console.Write ("> ");
                                newValue = Console.ReadLine();
                                break;
                            case 4:
                                columnToEdit = "QuantityAvailable";
                                Console.WriteLine ($"Enter new product QuantityAvailable");
                                Console.Write ("> ");
                                newValue= Console.ReadLine();
                                break;
                        }
                        productManager.updateProduct(Int32.Parse(productIdToEdit), columnToEdit, newValue);
                    }

                    if(choice == 9)
                    {
                        orderManager.GetRevenueReport();
                    }


                    if (choice == 6)
                    {
                        int? orderId = orderManager.CheckForIncompleteOrder();
                        string total = orderManager.GetOrderTotal(orderId);
                        Console.WriteLine($"Your order total is ${total}. Ready to purchase"); 
                        Console.WriteLine("(Y/N) >");
                        string answer = Console.ReadLine();
                        if (answer == "Y")
                        {
                            Console.WriteLine("Choose a payment option");
                            int customerId = ActiveCustomer.activeCustomerId;
                            List<PaymentType> paymentTypeList = payment.GetCustomerPaymentTypes(customerId);
                            int counter = 1;
                            foreach(PaymentType paymenttype in paymentTypeList)
                            {
                                Console.WriteLine($"{paymenttype.PaymentTypeId}. {paymenttype.Type}");
                                counter ++;
                            
                            }
                            Console.Write("> ");
                            string paymentChoice = Console.ReadLine();
                            int paymentChoiceNum = Int32.Parse(paymentChoice);
                            bool result = orderManager.AddPaymentTypeToOrder(paymentChoiceNum);
                            if (result == true)
                            {
                                Console.WriteLine("Your Order has been completed");
                            } else {
                                Console.WriteLine("Failed");
                            }
                        }
                        else {
                        }
                    }
                        //By: Ryan McCarty
                        //Menu option for DELETE
                        if(choice ==7)
                        {
                            Console.WriteLine("*************************************************");
                            Console.WriteLine("Choose a product to delete");
                            int customerId = ActiveCustomer.activeCustomerId;
                            List<Product> activeCustProducts= productManager.getActiveCustomersNonOrderProdcuts(customerId);
                            foreach(var x in activeCustProducts)
                            {
                                Console.WriteLine($"{x.ProductId}. {x.Title} ");
                            }
                            Console.Write(">");
                            string prodChoice= Console.ReadLine();
                            Console.WriteLine(prodChoice);
                            int delProd= Int32.Parse(prodChoice);
                            bool result= productManager.deleteProduct(delProd);
                            if(result ==true)
                            {
                                Console.WriteLine("Product was deleted");
                            }
                            else
                            {
                                Console.WriteLine("Deletion failed");
                            }
                            
                        }

                
    

            } while (choice != 12);
        }
    }
}