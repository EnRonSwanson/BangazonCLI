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

        public List<Product> getCustomersProducts(int sellerId)
        {
            _db.Query($"select * from product where product.sellerId = {sellerId}",
            (SqliteDataReader reader) => {
                _products.Clear();
                while(reader.Read())
                {

                    Console.WriteLine($"\n\n{reader[7].ToString()}\n\n");

                    _products.Add(new Product(
                        reader.GetInt32(0),
                        reader.GetInt32(1),
                        reader.GetInt32(2),
                        reader[3].ToString(),
                        reader.GetInt32(4),
                        reader[5].ToString(),
                        reader.GetFloat(6),
                        DateTime.Parse(reader[7].ToString())
                    ));
                }
            });
            return _products;
        }
        public Product getSingleProduct(int productId)
        {
           	Product singleProduct= null;
             _db.Query($"select * from product where product.productId = {productId}",
             (SqliteDataReader reader) =>{
                 _products.Clear();
                while(reader.Read())
                {
                  singleProduct = new Product(reader.GetInt32(1),reader[3].ToString(),reader.GetInt32(4),reader[5].ToString(),reader.GetFloat(6),reader.GetInt32(2)){ProductId= reader.GetInt32(0)};   
                }
            });
            return singleProduct;
        }

        public bool updateProduct(int productId, string columnToEdit, string newValue)
        {
           _db.Update($"update product set {columnToEdit}='{newValue}' where productId= {productId}");
           return true;
        }

        public bool deleteProduct(int productId)
        {
            _db.Delete($"DELETE from product where product.productId={productId}");
            return true;
        }
        public List<Product> getActiveCustomersNonOrderProdcuts(int activeCustomer)
        {
            _db.Query($"select product.price, product.title, product.description,product.productid, product.sellerID, product.quantityavailable from product where product.productid not in (select orderproduct.productID from orderproduct) and product.sellerID= {activeCustomer}",
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
