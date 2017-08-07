using System;
using System.Collections.Generic;
using BangazonCLI.Models;

namespace BangazonCLI.Managers
{
    public class OrderManager
    {
        public Order CreateOrder(Product productToAdd)
        {
            return new Order();
        }

        public List<Order> GetAllOrdersForCustomer()
        {
            return new List<Order>();
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