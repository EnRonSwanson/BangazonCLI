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
            _customerModel= new Customer("Ryan McCarty", "3041 Old Field Way", "Lexington", "Ky",40513, "859-588-2850");
            _db = new DatabaseInterface("BANGAZON_CLI_DB");
            _customer= new CustomerManager(_db);
            _db.RunCheckForTable();
        }
        [Fact]
        public void AddNewCustomer()
        {
            Customer newCustomer = new Customer("Dude McDude", "Address", "City", "State", 37209, "111-222-333");
            int customerId = _customer.AddCustomer(newCustomer);
            Assert.True(customerId != 0);
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
