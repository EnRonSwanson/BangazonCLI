using System;
using System.Collections.Generic;
using BangazonCLI.Managers;
using BangazonCLI.Models;
using Xunit;

//Author: Andrew Rock, minor refactoring by Mitchell
//Tests for the Order Manager Methods

namespace BangazonCLI.Tests
{
    public class OrderManagerShould : IDisposable
    {

        private readonly OrderManager _orderManager;
        private readonly DatabaseInterface _db;
        
        public OrderManagerShould()
        {
            _db = new DatabaseInterface("BANGAZON_CLI_DB");
            _orderManager = new OrderManager(_db);
    
        }

        [Fact]
        public void CreateOrderShould()
        {
            CustomerManager _customerManager = new CustomerManager(_db);
            ActiveCustomer _activeManager = new ActiveCustomer();
            var newCustomerId = _customerManager.AddCustomer(new Customer("Ryan McCarty", "3041 Old Field Way", "Lexington", "Ky",40513, "859-588-2850"));
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
            Assert.Null(incompleteOrderId);
        }


        [Fact]
        public void AddPaymentTypeToOrderShould()
        {
            CustomerManager _customerManager = new CustomerManager(_db);
            ActiveCustomer _activeManager = new ActiveCustomer();
            PaymentTypeManager _paymentManager = new PaymentTypeManager(_db);
            var newCustomerId = _customerManager.AddCustomer(new Customer("Bob", "Some Street", "City", "TN", 12345, "5555555555"));
            _activeManager.setActiveCustomerId(newCustomerId);
            var newPayment = _paymentManager.CreatePaymentType(new PaymentType(newCustomerId, "Merit", "1"));
            var newOrderId = _orderManager.CreateOrder();
            var orderWithPayment = _orderManager.AddPaymentTypeToOrder(newPayment); //the parameter passed is the id of the payment type
            Assert.True(orderWithPayment);
            
        }
        [Fact]
        public void AddProductToOrderShould()
        {
            CustomerManager _customerManager = new CustomerManager(_db);
            ActiveCustomer _activeManager = new ActiveCustomer();
            ProductManager _productManager = new ProductManager(_db);
            ProductTypeManager _productTypeManager = new ProductTypeManager(_db);
            var newCustomerId = _customerManager.AddCustomer(new Customer("Bob", "Some Street", "City", "TN", 12345, "5555555555"));
            _activeManager.setActiveCustomerId(newCustomerId);
            var newProductTypeId = _productTypeManager.AddProductType(new ProductType("taco"));
            var newProductId = _productManager.CreateProduct(new Product(newProductTypeId, "taco", 25, "string description", 25, newCustomerId));
            var orderId = _orderManager.CreateOrder();
            var orderProductId = _orderManager.AddProductToOrder(newProductId, orderId);
            Assert.IsType<int>(orderProductId);
            
        }
        [Fact]
        public void GetAllCompletedOrdersShould()
        {
            var completedOrders = _orderManager.GetAllCompletedOrders();
            Assert.IsType<List<Order>>(completedOrders);
        }
        [Fact]
        public void GetOrderTotalShould()
        {
            CustomerManager _customerManager = new CustomerManager(_db);
            ActiveCustomer _activeManager = new ActiveCustomer();
            ProductManager _productManager = new ProductManager(_db);
            ProductTypeManager _productTypeManager = new ProductTypeManager(_db);
            var newCustomerId = _customerManager.AddCustomer(new Customer("Bob", "Some Street", "City", "TN", 12345, "5555555555"));
            _activeManager.setActiveCustomerId(newCustomerId);
            var newProductTypeId = _productTypeManager.AddProductType(new ProductType("taco"));
            var newProductId = _productManager.CreateProduct(new Product(newProductTypeId, "taco", 25, "string description", 25, newCustomerId));
            var orderId = _orderManager.CreateOrder();
            var orderProductId = _orderManager.AddProductToOrder(newProductId, orderId);
            string total = _orderManager.GetOrderTotal(orderId);
            Assert.True(total == "25");
        }
        public void Dispose()
        {
            _db.Delete("DELETE FROM [order]");
            _db.Delete("DELETE FROM customer");
            _db.Delete("DELETE FROM product");
            _db.Delete("DELETE FROM orderproduct");
            _db.Delete("DELETE FROM producttype");
        }
    }
}