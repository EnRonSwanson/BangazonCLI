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
        private string _connectionString = $"Data Source={Environment.GetEnvironmentVariable("BANGAZON_CLI_DB")}";
        private SqliteConnection _connection;
    
        public CustomerManager(DatabaseInterface db)
        {
            _db = db;
            _connection = new SqliteConnection(_connectionString);
        }

        public int AddCustomer(Customer cust)
        {
            var id= _db.Insert($"Insert into Customer values (null,'{cust.Name}','{cust.AccountCreationDate}','{cust.Street}','{cust.City}', '{cust.State}','{cust.zip}', '{cust.Phone}')");

            return id;
        }
        public List<Customer> getListCustomers(string name)
        {
            return new List<Customer>();
        }
        public Customer getSingleCustomer (int id) =>  _customer.SingleOrDefault(guy => guy.CustomerId == id);
        
    }
}