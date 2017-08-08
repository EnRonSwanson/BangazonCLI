using System;
using Xunit;
using System.Collections.Generic;
using BangazonCLI.Managers;
using BangazonCLI.Models;
using BangazonCLI;



namespace BangazonCLI.Tests
{
    public class CustomerManagerShould
    {
        //Create a new instance of CustomerManager
        private readonly CustomerManager _customer;
        private readonly Customer _customerModel;
         private readonly DatabaseInterface _db;
        private DateTime _datetime= DateTime.Now;
        public CustomerManagerShould()
        {
            _customerModel= new Customer("Ryan McCarty", "3041 Old Field Way", "Lexington", "Ky", "40513", "859-588-2850");
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
        public void getASingleCustomerToReturnAsActive()
        {
            int RyanMcCartyId = _customer.AddCustomer(_customerModel);
            var ryan = _customer.getSingleCustomer(RyanMcCartyId);
            Assert.IsType<Customer>(_customerModel);
        }

        [Fact]
        public void GetListOfAllCustomersShould()
        {
            var result = _customer.GetListCustomers();
            Assert.IsType<List<Customer>>(result);
        }
    }
}
