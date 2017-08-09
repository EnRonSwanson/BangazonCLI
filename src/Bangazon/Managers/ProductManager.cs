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
        private int _custProd;
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

        public Product setSingleProduct(int productId)
        {
           	Product singleProduct= null;
             _db.Query($"select * from product where product.productId = {productId}",
             (SqliteDataReader reader) =>{
                 _products.Clear();
                while(reader.Read())
                {
                  singleProduct =new Product(reader.GetInt32(1),reader[2].ToString(),reader.GetInt32(3),reader[4].ToString() ,reader.GetInt32(5),reader.GetInt32(6)  ){ProductId= reader.GetInt32(0)};
                        
                  
                }
 
            });
            return singleProduct;
        }
        public void editProduct(int productId)
        {
            
        }

        public List<Product> GetListOfProducts()
        {
            _db.Query("select productid, title from product",
                (SqliteDataReader reader) => {
                    _products.Clear();
                    while (reader.Read ())
                    {
                        _products.Add(new Product(
                            reader.GetInt32(0),
                            reader[1].ToString()
                        ));
                    }
                }
            );

            return _products;
        }

    }
}
