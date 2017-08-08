using System;
using System.Collections.Generic;
using BangazonCLI.Models;
using Microsoft.Data.Sqlite;

// Authors: Madeline and Mitchell
// Accessible methods regarding Product

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
            // Inserting new product into db
            int newProductId = _db.Insert( $@"insert into product values (
            null, 
            '{product.ProductTypeId}', 
            '{product.SellerId}', 
            '{product.Title}', 
            '{product.QuantityAvailable}', 
            '{product.Description}', 
            '{product.Price}', 
            '{product.DateCreated}')");

            return newProductId;
        }

        public int GetSingleProduct(int productId)
        {
            int id = productId;
            return id;
        }


    }
}
