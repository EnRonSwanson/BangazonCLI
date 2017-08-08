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
            var newOrderId = _manager.CreateOrder();
            Assert.IsType<int>(newOrderId);

        }
        [Fact]
        public void GetIncompleteOrderForCustomerShould()
        {
            var incompleteOrderId = _manager.GetIncompleteOrderForCustomer();
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