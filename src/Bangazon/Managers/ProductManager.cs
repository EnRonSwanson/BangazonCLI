using System;
using System.Collections.Generic;
using BangazonCLI.Models;
using Microsoft.Data.Sqlite;

namespace BangazonCLI.Managers
{
    public class ProductManager
    {
        private List<Product> _products = new List<Product>();
        private DatabaseInterface _db;
        public ProductManager(DatabaseInterface db)
        {
            _db = db;
        }
        public int CreateProduct(Product product)
        {
            // Inserting new producet into db
            int newProductId = _db.Insert( $"insert into product values (null, '{product.ProductTypeId}', '{product.Title}', '{product.QuantityAvailable}', '{product.Description}', '{product.Price}', '{product.SellerId}')");

            // Create new instance of product
            Product newProduct = new Product()
            {
                ProductId = newProductId,
                ProductTypeId = product.ProductTypeId,
                Title = product.Title,
                QuantityAvailable = product.QuantityAvailable,
                DateCreated = DateTime.Now,
                Description = product.Description,
                Price = product.Price,
                SellerId = product.SellerId
            };

            // Add to private product collection
            _products.Add(newProduct);

            return newProduct.ProductTypeId;              // make this an int!
        }

        public int GetProduct(int productId)
        {
            int id = productId;
            return id;
        }
    }
}
