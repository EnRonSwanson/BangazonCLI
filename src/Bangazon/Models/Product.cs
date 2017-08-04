using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BangazonCLI.Models
{
    public class Product 
    {
        public int ProductId { get; set; }
        public int ProductTypeId { get; set; }
        public string Title { get; set;}
        
        public int QuantityAvailable {get; set;}
        public DateTime DateCreated {get; set;}
        public string Description {get; set;}
        public float Price {get; set;}
        public int SellerId { get; set; } //this is the same as CustomerId

        public Product(int id, int producttypeid, string title, int available, DateTime Date, string description, float price, int customerId)
        {
                    ProductId = id;
                    ProductTypeId = producttypeid;
                    Title = title;
                    QuantityAvailable = available;
                    DateCreated = Date;
                    Description = description;
                    Price = price;
                    SellerId = customerId;
        }
    }

    
}