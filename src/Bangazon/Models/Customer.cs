using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BangazonCLI.Models
{
  //Purpose: Contain customer info, including potential products to sell and customer's orders
  //Auther: Team code
  //Methods: Customer constructor method to set default values (1 is true and 0 is false) and date account is created
  public class Customer
  {
    public int CustomerId { get; set; }
    public string Name { get; set; }
    public DateTime AccountCreationDate { get; set; }
 

  }
}