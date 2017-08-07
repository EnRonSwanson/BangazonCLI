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
        public PaymentTypeManager(DatabaseInterface db)
        {
            _db = db;
        }

        public PaymentType CreatePaymentType()
        {
            return new PaymentType();
        }
    }
}