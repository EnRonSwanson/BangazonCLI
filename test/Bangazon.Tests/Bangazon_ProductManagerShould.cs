using System;
using System.Collections.Generic;
using BangazonCLI.Models;
using BangazonCLI.Managers;
using BangazonCLI;
using Xunit;

// Authors: Madeline and Mitchell
// Tests Product Manager

namespace Bangazon.Tests
{
    public class ProductManagerShould: IDisposable
    {
        private readonly DatabaseInterface _db;
        private readonly ProductManager _productManager;
        private readonly ProductTypeManager _productTypeManager;
        public ProductManagerShould()
        {
            _db = new DatabaseInterface("BANGAZON_CLI_DB");
            _productManager = new ProductManager(_db);
            _productTypeManager = new ProductTypeManager(_db);
            _db.RunCheckForTable();
        }

        //Purpose: Test is creating a new product type, creating a new product, and asserting the returned product id is not null)
        [Fact]
        public void CreateProductShould()
        {
            ProductType newProductType = new ProductType("Home Decor");
            int typeid = _productTypeManager.AddProductType(newProductType);
            Product product = new Product(typeid , "Rug", 5, "Awesome shag rug - 8x10", 125.99f, 1);
            int productThatWasCreated = _productManager.CreateProduct(product);
            Assert.IsType<int>(productThatWasCreated);
        }
        
        //Purpose: Test creates new product and product type, then retrieves the same product and asserts that the added Product id is equal to the result id
        [Fact]
        public void setProductShould()
        {
            ProductType newProductType = new ProductType("Home Decor");
            int typeid = _productTypeManager.AddProductType(newProductType);
            Product product = new Product(typeid , "Rug", 5, "Awesome shag rug - 8x10", 125.99f, 1);
            int productThatWasCreated = _productManager.CreateProduct(product);
            var result = _productManager.setSingleProduct(productThatWasCreated);
            Assert.IsType<Product>(result);
        }
        [Fact]
        public void updateACustomersProduct()
        {
            ProductType newProductType = new ProductType("Home Decor");
            int typeid = _productTypeManager.AddProductType(newProductType);
            Product product = new Product(typeid , "Rug", 5, "Awesome shag rug - 8x10", 125.99f, 1);
            int productThatWasCreated = _productManager.CreateProduct(product);
            product.Description= "Cool rug";
            var result= _productManager.updateProduct(productThatWasCreated, product);
            Assert.True(result);

        }

        //Author: Madeline
        [Fact]
        public void GetListofProducts()
        {
            Product product1 = new Product(1, "Blue Rug", 5, "Awesome blue rug", 130.05f, 1);
            Product product2 = new Product(1, "Rug", 5, "Awesome shag rug - 8x10", 125.99f, 1);
            int product1ThatWasCreated = _productManager.CreateProduct(product1);
            int product2ThatWasCreated = _productManager.CreateProduct(product2);
            List<Product> listofProducts = _productManager.GetListOfProducts();
            Assert.IsType<List<Product>>(listofProducts);
        }

        public void Dispose()
        {
            _db.Delete("DELETE FROM product");
            _db.Delete("DELETE FROM productType");
        }
    }
}