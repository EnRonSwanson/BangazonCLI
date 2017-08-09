using System;
using System.ComponentModel;

//Author: Andrew Rock
//Creates the Order object for the program to interact with

namespace BangazonCLI.Models
{
    public class Order
    {
        public int orderID {get; set;}
        public int customerId {get; set;}
        public int? paymentTypeId {get; set;}
        public DateTime dateCreated {get; set;}
        public DateTime? dateCompleted {get; set;}
        public Order(int customerId)
        {
            this.customerId = customerId;
            this.paymentTypeId = null;
            this.dateCreated = DateTime.Now;
            this.dateCompleted = null;
        }

    }
    

}