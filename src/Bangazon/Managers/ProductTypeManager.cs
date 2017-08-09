using System;
using System.Collections.Generic;
using BangazonCLI.Models;
using Microsoft.Data.Sqlite;

// Author: Mitchell

namespace BangazonCLI.Managers
{
    public class ProductTypeManager
    {
        private List<ProductType> _producttype = new List<ProductType>();
        private DatabaseInterface _db;
        public ProductTypeManager(DatabaseInterface db)
        {
            _db = db;
        }

        // Adds Product type from user input string when an existing one is not selected when adding new product
        public int AddProductType(ProductType productTypeName)
        {
            int id = _db.Insert( $"insert into producttype values (null, '{productTypeName.Type}')");
            return id;
        }

        //Queries DB for all product types, adds them to a list, returns that list for use on the interface
        public List<ProductType> GetListProductTypes()
        {
            _db.Query("select * from producttype",
                (SqliteDataReader reader) => {
                    _producttype.Clear();
                    while (reader.Read ())
                    {
                        _producttype.Add(new ProductType(
                            reader[1].ToString()));
                    }
                });
            return _producttype;
        }
    }
}