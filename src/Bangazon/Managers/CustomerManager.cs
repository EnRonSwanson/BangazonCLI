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
            //int id= _db.Insert=($"Insert into Customer values({null},{cust.Name}, {cust.AccountCreationDate}, {cust.Street}, {cust.City}, {cust.State},{cust.zip}, {cust.Phone}");
            return 5;
        }
        public List<Customer> getListCustomers(string name)
        {
            return new List<Customer>();
        }
        public Customer getSingleCustomer (int id) =>  _customer.SingleOrDefault(guy => guy.CustomerId == id);
        
    }
}