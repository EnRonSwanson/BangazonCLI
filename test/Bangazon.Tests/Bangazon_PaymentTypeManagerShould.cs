using System;
using Xunit;
using System.Collections.Generic;
using BangazonCLI.Managers;
using BangazonCLI.Models;

//Author: Andrew Rock
//Creates tests for the PaymentType Manager

namespace BangazonCLI.Tests
{
    public class PaymentTypeManagerShould
    {
        private readonly PaymentTypeManager _manager;
        private readonly DatabaseInterface _db;

        public PaymentTypeManagerShould()
        {
            _manager= new PaymentTypeManager(_db);
            _db = new DatabaseInterface("BAGOLOOT_TEST_DB"); 
        }
        [Fact]
        public void CreatePaymentTypeShould()
        {
            var newPayment = _manager.CreatePaymentType();
            Assert.IsType<PaymentType>(newPayment);
        } 
        
    }
}