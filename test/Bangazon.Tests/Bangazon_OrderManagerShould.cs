using System;
using System.Collections.Generic;
using BangazonCLI.Managers;
using BangazonCLI.Models;
using Xunit;

//Author: Andrew Rock, minor refactoring by Mitchell
//Tests for the Order Manager Methods

namespace BangazonCLI.Tests
{
    public class OrderManagerShould //: IDisposable
    {

        private readonly OrderManager _manager;
        private readonly DatabaseInterface _db;
        
        public OrderManagerShould()
        {
            _manager = new OrderManager(_db);
        }

        [Fact]
        public void CreateOrderShould()
        {
            CustomerManager _customerManager = new CustomerManager(_db);
            ActiveCustomer _activeManager = new ActiveCustomer();
            var newCustomerId = _customerManager.AddCustomer(new Customer("Bob", "Some Street", "City", "TN", 12345, "5555555555"));
            _activeManager.setActiveCustomerId(newCustomerId);
            var newOrderId = _manager.CreateOrder();
            Assert.IsType<int>(newOrderId);

        }
        [Fact]
        public void CheckForIncompleteOrderShould()
        {
            var newOrderId = _manager.CreateOrder();
            var incompleteOrderId = _manager.CheckForIncompleteOrder();
            Assert.IsType<int?>(incompleteOrderId);
        }


        [Fact]
        public void AddPaymentTypeToOrderShould()
        {
            var orderWithPayment = _manager.AddPaymentTypeToOrder(1); //the parameter passed is the id of the payment type
            Assert.True(orderWithPayment);
            
        }

        [Fact]
        public void GetAllCompletedOrdersShould()
        {
            var completedOrders = _manager.GetAllCompletedOrders();
            Assert.IsType<List<Order>>(completedOrders);
        }

        // public void Dispose()
        // {
        //     _db.Delete("DELETE FROM product");
        //     _db.Delete("DELETE FROM order");
        // }
    }
}