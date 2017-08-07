 using System;
using System.Collections.Generic;
using BangazonCLI.Models;
using BangazonCLI.Managers;
using BangazonCLI;
using Xunit;

namespace Bangazon.Tests
{
    public class ProductTypeManagerShould: IDisposable
    {
        private readonly DatabaseInterface _db;
        private readonly ProductTypeManager _productTypeManager;
        public ProductTypeManagerShould()
        {
            _db = new DatabaseInterface("BANGAZON_CLI_DB");
            _productTypeManager = new ProductTypeManager(_db);
            _db.RunCheckForTable();
        }

        //Purpose: Test is creating a new product type and asserting the returned product type id is not null)
        [Fact]
        public void AddProductTypeShould()
        {
            ProductType newProductType = new ProductType( "Home Decor");
            int typeid = _productTypeManager.AddProductType(newProductType);
            Assert.True(typeid != 0); 
        }

        public void Dispose()
        {
            _db.Delete("DELETE FROM product");
            _db.Delete("DELETE FROM productType");
        }
    }
}