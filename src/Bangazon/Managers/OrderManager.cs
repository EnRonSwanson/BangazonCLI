using System;
using System.Collections.Generic;
using BangazonCLI.Models;
using Microsoft.Data.Sqlite;
using BangazonCLI.Managers;
using BangazonCLI;

namespace BangazonCLI.Managers
{
    //Initial Methods by: Andrew Rock
    public class OrderManager
    {
        ActiveCustomer activeManager = new ActiveCustomer();
        private List<Order> _orderList = new List<Order>();
        private DatabaseInterface _db;
        public OrderManager(DatabaseInterface db)
        {
            _db = db;
        }
        //Method Author: Andrew Rock 
        //Creates a new open order 
        public int CreateOrder()
        {
            //Checks to see if there is already an existing incomplete order
            int? existingOrder = CheckForIncompleteOrder();
            if(existingOrder != null)
            {
                return (int)existingOrder;

            } else
            {
                //if no incomplete order already exists then make a new one
                int? customerID = ActiveCustomer.activeCustomerId;
                Order newOrder = new Order((int)customerID);
                int newOrderId= _db.Insert($"INSERT INTO [order] VALUES (null, {customerID}, null, '{DateTime.Now}', null)");
                return newOrderId; 
            }
        }

        //Method Author: Andrew Rock
        //Checks to see if the actie customer already has an incomplete order
        //returns null if no incomplete order, otherwise returns id of incomplete order
        public int? CheckForIncompleteOrder()
        {
            int? customerID = ActiveCustomer.activeCustomerId;
            int? incompleteOrderId = null;
            _db.Query($"SELECT o.orderid FROM [order] o WHERE o.customerId = {customerID} AND o.paymentTypeId IS NULL",
                    (SqliteDataReader reader) => {
                    while (reader.Read ())
                    {
                        incompleteOrderId = reader.GetInt32(0);
                        
                    }
                });

            return incompleteOrderId;
        }
        //Method Author: Andrew Rock
        //Finds the outstanding incomplete order and active customer
        // and then assigns the payment type passed into the method onto the order

        public bool AddPaymentTypeToOrder(int paymentTypeId)
        {
            int customerID = (int)ActiveCustomer.activeCustomerId;
            int orderId = (int)CheckForIncompleteOrder();
            string dateCreated = "";
            _db.Query($"SELECT o.datecreated FROM [order] o WHERE o.orderid = {orderId}",
                            (SqliteDataReader reader) => {
                                while (reader.Read ())
                                {
                                    dateCreated = reader[0].ToString();
                        
                                }
                            });
            _db.Update($"UPDATE [order] SET paymenttypeid = {paymentTypeId}, DateCompleted = '{DateTime.Now}' WHERE orderid = {orderId}");
            return true;
        }
        //Method Author: Andrew Rock
        // Method does what it says, added a product to an order through a join table
        public int AddProductToOrder(int addedProductId, int orderId)
        {
            var orderProductId = _db.Insert($"INSERT INTO orderproduct VALUES (null, {orderId}, {addedProductId})");
            return orderProductId;
        }

        public string GetOrderTotal(int? orderId)
        {
            string total = "0";
            _db.Query($"select sum(p.price) from Product p, OrderProduct op where op.OrderID = {orderId} and op.productid = p.productId",
                            (SqliteDataReader reader) => {
                                while (reader.Read ())
                                {
                                  total = reader[0].ToString();
                                }
                            });
            return total;            
        }
        
        public List<Order> GetAllCompletedOrders()
        {
            return new List<Order>();
        }
        //Method Author: Andrew Rock
        //This Method queries, and prints to console, a revenue report for the current active customer.  
        public void GetRevenueReport()
        {
            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!");
            Console.WriteLine("Revenue Report");
            Console.WriteLine("!!!!!!!!!!!!!!!!!!!!!!!!!!");
            int currentActiveCust = ActiveCustomer.activeCustomerId;
            List<int> completeOrderIds = new List<int>();
            List<(string, int, float)> reportFields = new List<(string, int, float)>();
            _db.Query($"SELECT DISTINCT op.orderid FROM orderproduct op, product p, [order] o WHERE p.sellerid = {currentActiveCust} AND op.productid = p.productid AND op.orderid = o.orderid AND o.paymenttypeid IS NOT NULL",
                    (SqliteDataReader reader) => {
                                while (reader.Read ())
                                {
                                    completeOrderIds.Add(reader.GetInt32(0));                        
                                }
                    });
            foreach(var order in completeOrderIds)
            {
                reportFields.Clear();
                Console.WriteLine($"Order #{order}");
                Console.WriteLine("-------------------------");
                _db.Query($"SELECT p.title, COUNT(op.productid), p.price FROM product p, orderproduct op WHERE op.orderid = {order} AND p.sellerid = {currentActiveCust} AND p.productid = op.productid GROUP BY op.productid",
                    (SqliteDataReader reader) => {
                                while (reader.Read ())
                                {
                                    reportFields.Add((reader[0].ToString(), reader.GetInt32(1), reader.GetFloat(2)));                        
                                }
                    });
                foreach(var product in reportFields)
                {
                    Console.WriteLine($"{product.Item1} {product.Item2} ${product.Item3*product.Item2}");
                }
                Console.WriteLine("");

            }
        }


    }
}