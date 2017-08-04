using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

//Purpose: Display the productType info with a collection of Products

namespace BangazonCLI.Models
{
  public class ProductType
  {
    public int ProductTypeId { get; set; }
    public string Type { get; set; }

    public ProductType(int id, string type)
    {
        ProductTypeId = id;
        Type = type;
    }
  }  
}