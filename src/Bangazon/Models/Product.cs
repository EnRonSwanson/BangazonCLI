using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

// written by Madeline and Mitchell
// commented by Mitchell
// establishes Product class for use by Manager files, especially ProductManager

namespace BangazonCLI.Models
{
    public class Product 
    {
        public int? ProductId { get; set; }
        public int ProductTypeId { get; set; }      // user input from selection or adding new product type
        public string Title { get; set;}            // user input
        
        public int QuantityAvailable {get; set;}    // user input
        public DateTime DateCreated {get; set;}     // auto generated
        public string Description {get; set;}       // user input
        public float Price {get; set;}              // user input
        public int SellerId { get; set; }           // this is the same as CustomerId

        // this method accepting six attributes is for creating a new one.
        public Product(int producttypeid, string title, int available, string description, float price, int customerId)
        {
            ProductId = null;
            ProductTypeId = producttypeid;
            Title = title;
            QuantityAvailable = available;
            DateCreated = DateTime.Now;
            Description = description;
            Price = price;
            SellerId = customerId;
        }

        // this method accepting eight attributes is for editing an existing one in the db
        public Product(int productid, int producttypeid, int customerId,  string title, int available, string description, float price, DateTime datecreated)
        {
            ProductId = productid;
            ProductTypeId = producttypeid;
            SellerId = customerId;
            Title = title;
            QuantityAvailable = available;
            DateCreated = datecreated;
            Description = description;
            Price = price;
        }

        public Product(int productId, string title)
        {
            ProductId = productId;
            Title = title;
        }
  }

    
}