using System;
using System.Collections.Generic;
using BangazonCLI.Models;
using Microsoft.Data.Sqlite;

// Authors: Madeline, Mitchell, and Ryan
// Accessible methods regarding Product

namespace BangazonCLI.Managers
{
    public class ProductManager
    {
        private List<Product> _products = new List<Product>();
        private DatabaseInterface _db;
        // private int _custProd;
        public ProductManager(DatabaseInterface db)
        {
            _db = db;
        }

        //INSERT A NEW PRODUCT INTO THE PRODUCT TABLE
        //by: Madeline
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
            '{product.DateCreated.ToString("yyyy-MM-dd")}')");

            return newProductId;
        }

        //RETURNS A LIST OF EVERY PRODUCT THAT HAS BEEN CREATED BY THE CUSTOMER
        //by: Ryan
        public List<Product> getCustomersProducts(int sellerId)
        {
            _db.Query($"select * from product where product.sellerId = {sellerId}",
            (SqliteDataReader reader) => {
                _products.Clear();
                while(reader.Read())
                {

                    Console.WriteLine($"Product was created on: \n{reader[7].ToString()}\n");                   

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
        //SELECTS 1 PRODUCT FROM THE ACTIVE CUSTOMER
        //by: Ryan
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

        //SELECTING AN ACTIVE CUSTOMERS PRODUCT WE CAN PASS IN THE VALUES WE WANT TO CHANGE
        //by: Ryan and Mitchell
        public bool updateProduct(int productId, string columnToEdit, string newValue)
        {
           _db.Update($"update product set {columnToEdit}='{newValue}' where productId= {productId}");
           return true;
        }

        //AFTER RECEIVING AN ACTIVE CUSTOMERS PRODUCTID
        //IT CAN THEN BE DELTED FROM THE DATABASE
        //by: Ryan
        public bool deleteProduct(int prodId)
        {
            _db.Delete($"DELETE from product where productId={prodId}");
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
                            reader.GetInt32(3),
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

        // by Ryan
        public List<Product> getAllStaleProducts()
        {
            _db.Query("select p.productId, p.title, p.datecreated 'Product Created', p.quantityavailable from Product p where p.productid NOT IN (select productid from OrderProduct) and p.datecreated < date('now', '-180 day') union select product.productid, product.title, product.datecreated 'Product Created', product.quantityavailable from orderproduct join product on product.productid= orderproduct.productID join [order] on [order].orderid = orderproduct.orderID where [order].datecreated < date('now', '-90 day') and [order].paymenttypeID is null union select product.productid, product.title, product.datecreated 'Product Created', product.quantityavailable from orderproduct join product on product.productid= orderproduct.productID join [order] on [order].orderid = orderproduct.orderID where product.datecreated < date('now', '-180 day') and [order].paymenttypeID is not null and product.quantityavailable !=0",
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
