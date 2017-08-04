using System;
using System.Collections.Generic;
using BangazonCLI.Models;

namespace BangazonCLI.Managers
{
    public class ProductManager
    {
        private DatabaseInterface _db;
        public ProductManager(DatabaseInterface db)
        {
            _db = db;
        }
        public int CreateProduct(Product product)
        {
            int id = _db.Insert( $"insert into product values (null, {product.ProductTypeId}, '{product.Title}', {product.QuantityAvailable}, {product.DateCreated}, '{product.Description}', {product.Price}, {product.SellerId})");

            return id;
        }

        public int GetProduct(int productId)
        {
           int id = _db.Query($"select {productId} from product");

           return id;
        }
    }
}