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
            var id= _db.Insert($"Insert into Customer values (null,'{cust.Name}','{cust.AccountCreationDate}','{cust.Street}','{cust.City}', '{cust.State}', {cust.zip}, '{cust.Phone}')");

            return id;
        }

        //Method Author: Andrew Rock
        //Queries DB for all customers and adds them to a list and returns that list
        public List<Customer> GetListCustomers()
        {
            _db.Query("select * FROM customer",
                (SqliteDataReader reader) => {
                    _customer.Clear();
                    while (reader.Read ())
                    {
                        _customer.Add(new Customer(
                            reader[1].ToString(), 
                            reader[3].ToString(), 
                            reader[4].ToString(), 
                            reader[5].ToString(), 
                            reader.GetInt32(6),  
                            reader[7].ToString()));
                    }
                });

            return _customer;
        }
        
    }
}