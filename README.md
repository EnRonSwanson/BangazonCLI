# Bangazon Platform CLI - team EnRonSwanson

## Steps to install the code
 - Create environment variable for a database file and call the variable "BANGAZON_CLI_DB". 
 - Clone from github using `git clone https://github.com/EnRonSwanson/BangazonCLI.git`
 - cd into the created directory
 - cd into the src/bangazon folder 
 - Execute `dotnet restore`
 - Execute `dotnet run`

## How to install any dependencies
 - Requires dotnet core

## Contributors
- Madeline Power - https://github.com/madelineepower
- Andrew Rock - https://github.com/arock83
- Ryan McCarty - https://github.com/therealrmac
- Mitchell Blom - https://github.com/mitchellblom

# Bangazon Command Line Interface for a Database

This is a command line interface program for the database fo a simulated company, Bangazon.  This program tracks customers, products, product types, orders, payments, and payment types for users of the Bangazon system.   

*************************************************
Welcome to Bangazon! Command Line Ordering System
*************************************************
1. Create a customer account
2. Choose an active customer
3. Create a payment type
4. Add product to sell
5. Add Product to Shopping Cart
6. Complete an order
7. Remove customer product
8. Update product information
9. Show stale products
10. Get Revenue Report for customer
12. Leave Bangazon!

### Option 1. Create a customer account
This option allows the user to create a customer account in the bangazon system.  Customers in Bangazon can purchase products as well as post products for others to buy.  Option 1 in the program will promte the user to fill out all od the required information to create a customer account  in Bangazon.

### Option 2. Choose an active customer
This option allows the user to select which customer is currently active in the CLI.  An active customer IS REQUIRED for most functions int eh CLI interface.  Option 2 displays a list of all customers in Bangazon and the user selects the customer with which they would like to use to preform the other functions of the program.

### Option 3. Create a payment type
Once an active customer is chosen, a payment type can be created and saved to be possibly used later by that customer.

### Option 4. Add a product to sell
Once an active customer is chosen, option 4 allows them to post a product on the Bangazon system that they would like to sell to other Bangazon users.  A title, decrciption, price, and quantity are required nfor a complete product listing.

### Option 5. Add product to shopping cart
This option checks if there is an open shopping cart for the customer, and if there isn't, create a new open shopping cart.  It then displays all available products avaiable for sale on Bangazon and the customer can choose which product they want to add to their shopping cart.

### Option 6. Complete an order
If the customer has selected product to purchase, this option displays a list of payment types associated with that customer.  The user then can choose which payment type they would like to apply to their open order, completing the transaction.

### Option 7. Remove customer product
This option allows the customer to remove any product they has already posted for sale  from the Bangazon system.

### Option 8. Update product information
This option allows the customer to change any of the information of a product that they have already posted for sale.  The program will display a list of the customer's products and prompt them to choose which one they would like to edit.

### Option 9. Show stale products
This option displays a report of product from all customers that have been deemed stale in Bangazon.  Stale products are products that have been in the system for 180 days without a sale, or have been in the system for 180 days since their last purchase.

### Option 10. Get Revenue Report for customer
This option displays a report showing all products sold, and their totals for a current active customer.  The report is divided by which orders the purchases occured on.  

### Option 12.  Leave Bangazon!
This option closes out of Bangazon CLI program.

 