using System;
using Xunit;
using System.Collections.Generic;
using BangazonCLI.Managers;
using BangazonCLI.Models;



namespace BangazonCLI.Tests
{
    public class CustomerManagerShould
    {
        //Create a new instance of CustomerManager
        private readonly CustomerManager _customer;
        private readonly Customer _customerModel;
         private readonly DatabaseInterface _db;
        public CustomerManagerShould()
        {
            _customerModel= new Customer();
            _customer= new CustomerManager(_db);
            _db = new DatabaseInterface("BAGOLOOT_TEST_DB");
            _db.CheckChildTable();
            _db.CheckToyTable();
        }
        [Theory]
        [InlineData(_customerModel)]
        public void AddNewCustomer(Customer cust)
        {
            var result= _customer.AddCustomer(cust);
            Assert.True(result != 0);
        }
        [Fact]
        public void getASingleCustomerToReturnAsActive(Customer cust)
        {
            int RyanMcCartyId = _customer.AddCustomer(cust);
            Customer ryan = _customer.getSingleCustomer(RyanMcCartyId);
            Assert.True(ryan.CustomerId == RyanMcCartyId);
        }

        [Fact]
        public void getListOfAllCustomers()
        {
            _customer.getListCustomers("Ryan McCarty");
            List<Customer> customer = _customer.getListCustomers();
            Assert.IsType<List<Customer>>(customer);
            Assert.True(customer.Count > 0);
        }
    }
}
