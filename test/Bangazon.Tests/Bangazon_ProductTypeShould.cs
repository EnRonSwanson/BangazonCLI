using System;
using Xunit;
using BangazonCLI.Models;

namespace Bangazon.Tests
{
    public class ProductTypeShould
    {
        private ProductType _productType;
        private DateTime _dateTime = DateTime.Now;
        public ProductTypeShould()
        {
            _productType = new ProductType(1, "Home Decor");
        }

        [Fact]
        public void addProductType()
        {
            Assert.Equal(_productType.ProductTypeId, 1);
            Assert.Equal(_productType.Type, "Home Decor");
        }

    }
}