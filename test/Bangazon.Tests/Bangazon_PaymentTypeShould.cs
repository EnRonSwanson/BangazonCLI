using System;
using Xunit;
using BangazonCLI.Models;

namespace Bangazon.Tests
{
    public class PaymentTypeShould
    {
        //Author: Madeline
        //Purpose: Test for the contructor method
        private PaymentType _paymentType;
        public PaymentTypeShould()
        {
            _paymentType = new PaymentType(1, "Visa", "123");
        }

        [Fact]
        public void addPaymentType()
        {
            Assert.Equal(_paymentType.CustomerId, 1);
            Assert.Equal(_paymentType.Type, "Visa");
            Assert.Equal(_paymentType.AccountNumber, "123");
        }

    }
}