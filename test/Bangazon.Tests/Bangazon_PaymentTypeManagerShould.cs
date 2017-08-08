using System;
using Xunit;
using System.Collections.Generic;
using BangazonCLI.Managers;
using BangazonCLI.Models;

//Author: Andrew Rock
//Creates tests for the PaymentType Manager

namespace BangazonCLI.Tests
{
    public class PaymentTypeManagerShould: IDisposable
    {
        private readonly PaymentTypeManager _manager;
        private readonly DatabaseInterface _db;

        public PaymentTypeManagerShould()
        {
            _db = new DatabaseInterface("BANGAZON_CLI_DB"); 
            _manager= new PaymentTypeManager(_db);
            _db.RunCheckForTable();
        }
        //Author: Madeline
        //Purpose: Test is creating a new payne bt type and asserting the returned id is not null, confirming that the row was added to the database)
        [Fact]
        public void CreatePaymentTypeShould()
        {
            PaymentType newType = new PaymentType(1, "Visa", "123456-123456");
            int newPayment = _manager.CreatePaymentType(newType);
            Assert.True(newPayment != 0);
        } 

        public void Dispose()
        {
            _db.Delete("DELETE FROM paymentType");
        }

    }
}