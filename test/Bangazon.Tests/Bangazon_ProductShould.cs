using System;
using Xunit;
using BangazonCLI.Models;

namespace Bangazon.Tests
{
    public class ProductShould
    {
        private Product _product;
        private DateTime _dateTime = DateTime.Now;
        public ProductShould()
        {
            _product = new Product(1, "Chair", 2, _dateTime , "awesome chair", 100.99f, 1);
        }

        [Fact]
        public void addProduct()
        {
            Assert.Equal(_product.ProductTypeId, 1);
            Assert.Equal(_product.Title, "Chair");
            Assert.Equal(_product.QuantityAvailable, 2);
            Assert.Equal(_product.DateCreated, _dateTime);
            Assert.Equal(_product.Description, "awesome chair");
            Assert.Equal(_product.Price, 100.99f);
            Assert.Equal(_product.SellerId, 1);
        }

    }
}