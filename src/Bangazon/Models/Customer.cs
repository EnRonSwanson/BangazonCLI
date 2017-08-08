using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BangazonCLI.Models
{
  //Purpose: Contain customer info, including potential products to sell and customer's orders
  //Author: Team code
  //Methods: Customer constructor method to set default values (1 is true and 0 is false) and date account is created
  public class Customer
  {

    public int CustomerId { get; set; }
    public string Name { get; set; }
    public DateTime AccountCreationDate { get; set; }
 
    public string Street {get; set;}
    public string City {get; set;}
    public string State {get; set;}
    public int zip {get;set;}
    public string Phone {get; set;}

    public Customer(string Name, string Street, string City, string State, int zip, string Phone)
    {
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