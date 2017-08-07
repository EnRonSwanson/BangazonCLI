using System;
using System.Collections.Generic;
using BangazonCLI.Models;
using BangazonCLI.Managers;
using BangazonCLI;
using Xunit;

namespace Bangazon.Tests
{
    public class ProductManagerShould: IDisposable
    {
        private readonly DatabaseInterface _db;
        private readonly ProductManager _productManager;
        private readonly ProductTypeManager _productTypeManager;
        public ProductManagerShould()
        {
            _db = new DatabaseInterface("BANGAZON_TEST_DB");
            _productManager = new ProductManager(_db);
            _db.CheckForTable();
        }

        //Purpose: Test is creating a new product type, creating a new product, and asserting the returned product id is not null)
        [Fact]
        public void CreateProductShould()
        {
            ProductType newProductType = new ProductType(1, "Home Decor");
            int typeid = _productTypeManager.AddProductType(newProductType);
            Product product = new Product(1, typeid , "Rug", 5, DateTime.Now, "Awesome shag rug - 8x10", 125.99f, 1);
            int productThatWasCreated = _productManager.CreateProduct(product);
            Assert.True(productThatWasCreated != 0);
        }
        
        //Purpose: Test creates new product and product type, then retrieves the same product and asserts that the added Product id is equal to the result id
        [Fact]
        public void GetProductShould(int productId)
        {
            int result = _productManager.GetProduct(productId);
            Assert.True(result != 0);
        }

        public void Dispose()
        {
            _db.Delete("DELETE FROM product");
            _db.Delete("DELETE FROM productType");
        }
    }
}