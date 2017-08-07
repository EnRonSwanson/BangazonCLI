using System;
using System.Collections.Generic;
using BangazonCLI.Models;
using Microsoft.Data.Sqlite;

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
           int id = 0;
           _db.Query($"select {productId} from product", 
           (SqliteDataReader reader) => {
                    while (reader.Read ())
                    {
                            id = reader.GetInt32(0);
 
                    }
                }
           );

            return id;

        }
    }
}
