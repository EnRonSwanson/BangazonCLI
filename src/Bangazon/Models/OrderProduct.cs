using System;
using System.ComponentModel;

//Author: Andrew Rock
//Creates the Order/Product object for the program to interact with

namespace BangazonCLI.Models
{
    public class OrderProduct
    {
        public int orderProductId {get; set;}
        public int orderId {get; set;}
        public int productId {get; set;}
    }
}