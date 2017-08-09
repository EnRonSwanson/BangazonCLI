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

        private readonly OrderManager _orderManager;
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
            var newOrderId = _orderManager.CreateOrder();
            Assert.IsType<int>(newOrderId);

        }
        [Fact]
        public void CheckForIncompleteOrderShould()
        {
            CustomerManager _customerManager = new CustomerManager(_db);
            ActiveCustomer _activeManager = new ActiveCustomer();
            var newCustomerId = _customerManager.AddCustomer(new Customer("Bob", "Some Street", "City", "TN", 12345, "5555555555"));
            _activeManager.setActiveCustomerId(newCustomerId);
            var incompleteOrderId = _orderManager.CheckForIncompleteOrder();
            Assert.IsType<int?>(incompleteOrderId);
        }


        [Fact]
        public void AddPaymentTypeToOrderShould()
        {
             CustomerManager _customerManager = new CustomerManager(_db);
            ActiveCustomer _activeManager = new ActiveCustomer();
            var newCustomerId = _customerManager.AddCustomer(new Customer("Bob", "Some Street", "City", "TN", 12345, "5555555555"));
            _activeManager.setActiveCustomerId(newCustomerId);
            var newOrderId = _orderManager.CreateOrder();
            var orderWithPayment = _orderManager.AddPaymentTypeToOrder(newOrderId); //the parameter passed is the id of the payment type
            Assert.True(orderWithPayment);
            
        }

        [Fact]
        public void GetAllCompletedOrdersShould()
        {
            var completedOrders = _orderManager.GetAllCompletedOrders();
            Assert.IsType<List<Order>>(completedOrders);
        }

        // public void Dispose()
        // {
        //     _db.Delete("DELETE FROM product");
        //     _db.Delete("DELETE FROM order");
        // }
    }
}