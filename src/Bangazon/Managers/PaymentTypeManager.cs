using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;
using BangazonCLI.Models;

//Author: Andrew Rock

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