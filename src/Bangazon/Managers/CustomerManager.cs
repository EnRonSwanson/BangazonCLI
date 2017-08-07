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
        public List<Customer> GetListCustomers()
        {
            _db.Query("select * FROM customer",
                (SqliteDataReader reader) => {
                    _customer.Clear();
                    while (reader.Read ())
                    {
                        _customer.Add(new Customer(
                            reader[1].ToString(), 
                            reader.GetDateTime(2), 
                            reader[3].ToString(), 
                            reader[4].ToString(), 
                            reader[5].ToString(), 
                            reader.GetInt32(6),  
                            reader[7].ToString()));
                    }
                });

            return _customer;
        }
        public Customer getSingleCustomer (int id) =>  _customer.SingleOrDefault(guy => guy.CustomerId == id);
        
    }
}