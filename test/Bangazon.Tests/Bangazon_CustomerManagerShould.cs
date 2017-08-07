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
        public CustomerManagerShould()
        {
            _customerModel= new Customer("Ryan McCarty","2017-08-07T09:57:53.6076182-05:00", "3041 Old Field Way", "Lexington", "Ky", 40513, "859-588-2850");
            _db = new DatabaseInterface("BANGAZON_CLI_DB");
            _customer= new CustomerManager(_db);
            _db.RunCheckForTable();
        }
        [Fact]
        public void AddNewCustomer()
        {
            Assert.Equal(_customerModel.Name, "Ryan McCarty");
            Assert.Equal(_customerModel.AccountCreationDate, "2017-08-07T09:57:53.6076182-05:00");
            Assert.Equal(_customerModel.Street, "3041 Old Field Way");
            Assert.Equal(_customerModel.City, "Lexington");
            Assert.Equal(_customerModel.State, "Ky");
            Assert.Equal(_customerModel.zip, 40513);
            Assert.Equal(_customerModel.Phone, "859-588-2850");

        }
        [Fact]
        public void getASingleCustomerToReturnAsActive()
        {
            int RyanMcCartyId = _customer.AddCustomer(_customerModel);
            var ryan = _customer.getSingleCustomer(RyanMcCartyId);
            Assert.IsType<Customer>(_customerModel);
        }

        [Fact]
        public void getListOfAllCustomers()
        {
            var result = _customer.getListCustomers("Ryan McCarty");
            Assert.IsType<List<Customer>>(result);
        }
    }
}
