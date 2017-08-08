using System;
using Xunit;
using System.Collections.Generic;
using BangazonCLI.Managers;
using BangazonCLI.Models;
using BangazonCLI;

// Author: Ryan and minor refactor by Mitchell
// Tests methods in Customer Manager

namespace BangazonCLI.Tests
{
    public class CustomerManagerShould : IDisposable
    {
        //Create a new instance of CustomerManager
        private readonly CustomerManager _customer;
        private readonly Customer _customerModel;
         private readonly DatabaseInterface _db;
        private DateTime _datetime= DateTime.Now;
        public CustomerManagerShould()
        {
            _customerModel= new Customer("Ryan McCarty", "3041 Old Field Way", "Lexington", "Ky", 40513, "859-588-2850");
            _db = new DatabaseInterface("BANGAZON_CLI_DB");
            _customer= new CustomerManager(_db);
            _db.RunCheckForTable();
        }
        [Fact]
        public void AddNewCustomer()
        {
            Assert.IsType<Customer>(_customerModel);
        }
        [Fact]
        public void setASingleCustomerToReturnAsActive()
        {
            string RyanMcCartyName = "Ryan McCarty";
            var ryan = _customer.setSingleCustomer(RyanMcCartyName);
            Assert.True(ryan !=0);
        }
        [Fact]
        public void getASingleCustomer()
        {
            string RyanMcCartyName = "Ryan McCarty";
            var ryan = _customer.setSingleCustomer(RyanMcCartyName);
            int result= _customer.getSingleCustomer();
            Assert.True(result !=0);
        }

        [Fact]
        public void GetListOfAllCustomersShould()
        {
            var result = _customer.GetListCustomers();
            Assert.IsType<List<Customer>>(result);
        }

              public void Dispose()
        {
            _db.Delete("DELETE FROM customer");
        }

    }
}
