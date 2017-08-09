using System;
using Microsoft.Data.Sqlite; 
using BangazonCLI;
using BangazonCLI.Models;

// Author: Mitchell
// Seeds data if doesn't already exist in the appropriate tables

namespace BangazonCLI
{
    public static class DBInitializer
    {
      // Runs check for a piece of existing data
      public static void Initialize(DatabaseInterface db)
      {
        bool checkForData = false; 
        db.Query($"select customerid from customer",
        (SqliteDataReader reader) => {
            while(reader.Read())
            {
                checkForData = true; 
            }
      // If no data returns from the simple test, then inserts the following into the created tables
          if(checkForData == false)
          {
            db.SeedData($@"
              insert into customer values(null, 'Nigel Thornberry', '20010618 11:12:13 AM', '123 Nickel Dr', 'Long Island', 'NY', '01234', '2222222222');
              insert into customer values(null, 'Kevin Spacey', '20010618 11:12:13 AM', '1900 Penn Ave', 'Washington', 'DC', '23445', '3333333333');
              insert into customer values(null, 'Pekka Rinne', '20010618 11:12:13 AM', '1511 Broadway', 'Nashville', 'TN', '37201', '4444444444');
              insert into [order] values (null, 1, null, '20150618 11:12:13 AM', null);
              insert into [order] values (null, 2, null, '20160618 11:12:13 AM', null);
              insert into [order] values (null, 3, null, '20170918 11:12:13 AM', null);
              insert into [order] values (null, 1, null, '20170818 11:12:13 AM', null);
              insert into [order] values (null, 2, null, '20170718 11:12:13 AM', null);
              insert into [order] values (null, 3, null, '20170618 11:12:13 AM', null);
              insert into orderProduct values (null, 1, 2);
              insert into orderProduct values (null, 2, 1);
              insert into orderProduct values (null, 3, 3);
              insert into paymentType values (null, 1, 'Visa', '987987987987');
              insert into paymentType values (null, 2, 'Mastercard', '876876876876');
              insert into paymentType values (null, 2, 'Amex', '765765765765');
              insert into producttype values (null, 'Home Goods');
              insert into producttype values (null, 'Accessories');
              insert into producttype values (null, 'Electronics');
              insert into product values (null, 1, 1, 'Lamp', 42, 'Lights stuff up', 22.98, '20120618 10:34:09 AM');
              insert into product values (null, 2, 2, 'Watch', 16, 'Tells time', 33.45, '20120618 10:34:09 AM');
              insert into product values (null, 3, 3, 'Headphones', 32, 'Plays music', 50.01, '20120618 10:34:09 AM');
              insert into product values (null, 1, 3, 'Table', 77, 'Corner or coffee', 5.51, '20170618 10:34:09 AM');
              insert into product values (null, 2, 1, 'Hat', 362, 'Looks great', 7.90, '20170718 10:34:09 AM');
              insert into product values (null, 3, 2, 'Laptop', 55, 'Runs programs', 890.01, '20170801 10:34:09 AM');
              "
            );
          }
      });
    }
  }
}