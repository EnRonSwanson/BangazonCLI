using System;
using System.Collections.Generic;
using BangazonCLI.Models;

namespace BangazonCLI.Managers
{
    public class ProductTypeManager
    {
        private DatabaseInterface _db;
        public ProductTypeManager(DatabaseInterface db)
        {
            _db = db;
        }
        public int AddProductType(ProductType productType)
        {
            int id = _db.Insert( $"insert into producttype values (null, '{productType.Type}')");
            return id;
        }
    }
}