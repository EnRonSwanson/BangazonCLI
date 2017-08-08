using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BangazonCLI.Models
{
  //Purpose: Contain Payment Type info
  //Auther: Andrew Rock
  
  public class PaymentType
  {
    public int PaymentTypeId { get; set; }
    public int CustomerId { get; set; }
    public string Type {get; set;}
    public string AccountNumber {get; set;}
 
    public PaymentType(int custId, string type, string accountNumber)
    {
      CustomerId = custId;
      Type = type;
      AccountNumber = accountNumber;

    }

  }
}