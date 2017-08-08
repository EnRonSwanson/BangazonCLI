using System;
using System.Collections.Generic;
using BangazonCLI.Models;
using Microsoft.Data.Sqlite;

namespace BangazonCLI.Managers
{
    //Initial Methods by: Andrew Rock
    public class OrderManager
    {
        
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
            int customerID = activeManager.getActiveCustomerId();
            Order newOrder = new Order(customerID);
            int newOrderId= _db.Insert($"INSERT INTO [order] (orderId, customerId, paymentTypeId, dateCreated, dateCompleted) VALUES (null, {customerID}, null, {DateTime.Now}, null)");
            return newOrderId; 
        }

        public int GetIncompleteOrderForCustomer()
        {
            ActiveCustomerManager activeManager = new ActiveCustomerManager();
            Order incompleteOrder = 
            _db.Query("SELECT o.orderid FROM [order] WHERE o.paymentTypeId =  null",
                        (SqliteDataReader reader) => );
        }


            ActiveCustomerManager activeManager = new ActiveCustomerManager();
            _orderList.Clear();
            _orderList = GetAllOrdersForCustomer();
            if (_orderList.Count > 0)
            {
                foreach(Order individualOrder in _orderList)
                {
                    if(individualOrder.paymentTypeId != null)
                    {
                        _orderList.Remove(individualOrder);
                    }
                }
                if()
                
            }
            else if(_orderList.Count == 0)
            {
                int customerID = activeManager.getActiveCustomerId();
                Order newOrder = new Order(customerID);
                 _db.Insert($"INSERT INTO [order] (orderId, customerId, paymentTypeId, dateCreated, dateCompleted) VALUES (null, {customerID}, null, {DateTime.Now}, null)");
            } 
            else {
                Console.WriteLine("!!!!ERROR IN ORDER MANAGER!!!!");
            }
           
            )
            return new Order();
        }

        public List<Order> GetAllOrdersForCustomer()
        {
            ActiveCustomerManager activeManager = new ActiveCustomerManager();
            int customerID = activeManager.getActiveCustomerId();
            _db.Query($"SELECT * FROM order o WHERE o.customerId = {customerID}", 
            (SqliteDataReader reader) => {
                    _orderList.Clear();
                    while (reader.Read ())
                    {
                        _orderList.Add(new Order());
                    }
                });
            return _orderList;
        }
        public Order AddPaymentTypeToOrder()
        {
            return new Order();
        }
        public List<Order> GetAllCompletedOrders()
        {
            return new List<Order>();
        }


    }
}