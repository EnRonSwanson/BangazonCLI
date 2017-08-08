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
 
    public string Street {get; set;}
    public string City {get; set;}
    public string State {get; set;}
     public string zip {get;set;}
    public string Phone {get; set;}

    public Customer(string Name, string Street, string City, string State, string zip, string Phone)
    {
      this.CustomerId= CustomerId;
      this.Name= Name;
      this.AccountCreationDate= DateTime.Now;
      this.Street= Street;
      this.City= City;
      this.State= State;
      this.zip= zip;
      this.Phone=Phone;
    }

  }
   
}