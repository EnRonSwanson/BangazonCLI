using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;
using System.Collections;

namespace BangazonCLI
{
    public class TableStatements
    {
        public string customerTable = $@"create table customer (
                            `customerid`	integer NOT NULL PRIMARY KEY AUTOINCREMENT,
                            `fullname`	varchar(80) not null,
                            `datecreated`	varchar(80) not null,
                            `address` varchar(80) not null,
                            `city` varchar(80) not null,
                            `state` varchar(2) not null,
                            `postalcode` int(5) not null,
                            `phone` int(10) not null
                        )";
        public string productTypeTable = $@"create table producttype (
                            `producttypeid` integer NOT NULL PRIMARY KEY AUTOINCREMENT,
                            `name` varchar(80) not null
                        )";
        public string paymentTypeTable = $@"create table paymenttype (
                            `paymenttypeid` integer NOT NULL PRIMARY KEY AUTOINCREMENT,
                            `customerID` integer not null default 0,
                            `accountnumber` interger not null,
                            `type` varchar(80)
                        )";
        public string orderTable = $@"create table [order] (
                            `orderid` integer NOT NULL PRIMARY KEY AUTOINCREMENT,
                            `customerID` integer not null default 0,
                            `paymenttypeID` integer,
                            `datecreated` varchar(80) not null,
                            `datecompleted` varchar(80)
                        )";
        public string orderProductTable = $@"create table orderproduct (
                            `orderproductid` integer NOT NULL PRIMARY KEY AUTOINCREMENT,
                            `orderID` integer not null default 0,
                            `productID` integer not null default 0
                        )";
        public string productTable = $@"create table product (
                            `productid` integer NOT NULL PRIMARY KEY AUTOINCREMENT,
                            `producttypeID` integer not null default 0,
                            `sellerID` integer not null default 0,
                            `title` varchar(80) not null,
                            `quantityavailable` integer NOT NULL default 0,
                            `description` varchar(80) not null,
                            `price` money not null,
                            `datecreated` date not null
                        )";
    }
}