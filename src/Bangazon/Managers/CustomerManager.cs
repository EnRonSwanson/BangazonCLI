using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;
using BangazonCLI.Models;

namespace BangazonCLI.Managers
{
    public class CustomerManager
    {
        private List<Customer> _customer = new List<Customer>();
        private DatabaseInterface _db;

        public CustomerManager(DatabaseInterface db)
        {
            _db = db;
        }

        public int AddCustomer(Customer cust)
        {
            int id= _db.Customer=($"insert into Customer values({null},{cust.Name}, {cust.AccountCreationDate})");
            return id;
        }
        public List<string> getListCustomers(string name)
        {
            return new List<string>();
        }
        public Customer getSingleCustomer (int id) =>  _customer.SingleOrDefault(guy => guy.CustomerId == id);
        
    }
}