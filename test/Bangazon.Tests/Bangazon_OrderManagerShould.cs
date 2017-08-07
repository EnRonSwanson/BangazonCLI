using System;
using System.Collections.Generic;
using BangazonCLI.Managers;
using BangazonCLI.Models;
using Xunit;

//Auther: Andrew Rock
//Tests for the Order Manager Methods

namespace BangazonCLI.Tests
{
    public class OrderManagerShould: IDisposable
    {

        private readonly OrderManager _manager;
        private readonly DatabaseInterface _db;
        
        public OrderManagerShould()
        {
            _manager = new OrderManager();
        }

        [Fact]
        public void CreateOrderShould()
        {
            Product kite = new Product(1, 1, "Kite", 2, DateTime.Now, "string description", 12, 1);
            var newOrder = _manager.CreateOrder(kite);
            Assert.IsType<Order>(newOrder);
        }

        [Fact]
        public void GetAllOrdersForCustomerShould()
        {
            var orderList = _manager.GetAllOrdersForCustomer();
            Assert.IsType<List<Order>>(orderList);
        }

        [Fact]
        public void AddPaymentTypeToOrderShould()
        {
            var orderWithPayment = _manager.AddPaymentTypeToOrder();
            Assert.IsType<Order>(orderWithPayment);
        }

        [Fact]
        public void GetAllCompletedOrdersShould()
        {
            var completedOrders = _manager.GetAllCompletedOrders();
            Assert.IsType<List<Order>>(completedOrders);
        }

        public void Dispose()
        {
            _db.Delete("DELETE FROM product");
            _db.Delete("DELETE FROM order");
        }
    }
}
