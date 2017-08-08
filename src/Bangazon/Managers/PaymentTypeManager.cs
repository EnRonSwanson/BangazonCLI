using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;
using BangazonCLI.Models;

// Authors: Andrew and Mitchell
// Interaction with payment type class instances

namespace BangazonCLI
{
    public class PaymentTypeManager
    {
        private DatabaseInterface _db;
        private List<PaymentType> _paymentTypes = new List<PaymentType>();
        public PaymentTypeManager(DatabaseInterface db)
        {
            _db = db;
        }
        //Author: Madeline
        //Insert new row into the payment type table
        public int CreatePaymentType(PaymentType paymentType)
        {
            int id = _db.Insert( $"insert into paymenttype values (null, {paymentType.CustomerId}, '{paymentType.Type}', '{paymentType.AccountNumber}')");
            return id;
        }

        public List<PaymentType> GetCustomerPaymentTypes(int customerId)
        {
            _db.Query($"select * FROM paymenttype WHERE customerID = {customerId}",
                (SqliteDataReader reader) => {
                    _paymentTypes.Clear();
                    while (reader.Read ())
                    {
                        _paymentTypes.Add(new PaymentType(
                            reader.GetInt32(1), 
                            reader[2].ToString(), 
                            reader[3].ToString()));
                    }
                });
            return _paymentTypes;
        }
    }
}