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
                int newOrderId= _db.Insert($"INSERT INTO [order] (orderId, customerId, paymentTypeId, dateCreated, dateCompleted) VALUES (null, {customerID}, null, {DateTime.Now}, null)");
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
            _db.Query($"SELECT o.orderid FROM [order] WHERE o.paymentTypeId =  null AND o.customerId = {customerID}",
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
            int confirmedID = _db.Insert($"INSERT INTO [order] o (o.orderid, o.customerid, o.paymentTypeID) VALUES ({orderId}, {customerID}, {paymentTypeId})");
            if(orderId == confirmedID)
            {
                return true;
            } else {
                return false;
            }
        }
        public void AddProductToOrder(Product addedProductId, Order orderId)
        {
            _db.Insert($"INSERT INTO orderproduct op VALUES ({orderId}, {addedProductId})");
        }
        public List<Order> GetAllCompletedOrders()
        {
            return new List<Order>();
        }


    }
}