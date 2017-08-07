using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Data.Sqlite;
using System.Collections;
using BangazonCLI.Models;

// Mitchell wrote the table check method and commented this file
// Andy wrote the SQL statements being passed in
// Query, Delete, and Insert began as boiler from previous exercises and may have light customization

namespace BangazonCLI
{
    public class DatabaseInterface
    {
        TableStatements table = new TableStatements();
        private string _connectionString;
        private SqliteConnection _connection;

        public DatabaseInterface(string database)
        {
            string env = $"{Environment.GetEnvironmentVariable(database)}";
            _connectionString = $"Data Source={env}";
            _connection = new SqliteConnection(_connectionString);
        }

        // reusable Query for passed desired action from any manager file
        public void Query(string command, Action<SqliteDataReader> handler)
        {
            using (_connection)
            {
                _connection.Open ();
                SqliteCommand dbcmd = _connection.CreateCommand ();
                dbcmd.CommandText = command;

                using (SqliteDataReader dataReader = dbcmd.ExecuteReader()) 
                {
                    handler (dataReader);
                }

                dbcmd.Dispose ();
                _connection.Close ();
            }
        }

        // reusable Delete for passed command from any manager file
        public void Delete(string command)
        {
            using (_connection)
            {
                _connection.Open ();
                SqliteCommand dbcmd = _connection.CreateCommand ();
                dbcmd.CommandText = command;
                
                dbcmd.ExecuteNonQuery ();

                dbcmd.Dispose ();
                _connection.Close ();
            }
        }

        // reusable Insert for passed command from any manager file
        public int Insert(string command)
        {
            int insertedItemId = 0;

            using (_connection)
            {
                _connection.Open ();
                SqliteCommand dbcmd = _connection.CreateCommand ();
                dbcmd.CommandText = command;
                
                dbcmd.ExecuteNonQuery ();

                this.Query("select last_insert_rowid()",
                    (SqliteDataReader reader) => {
                        while (reader.Read ())
                        {
                            insertedItemId = reader.GetInt32(0);
                        }
                    }
                );

                dbcmd.Dispose ();
                _connection.Close ();
            }

            return insertedItemId;
        }

        //variables passed into CheckForTable come from Data.TableStatements, whose using statement is at the top of this file
        public void RunCheckForTable() {
          CheckForTable("customer", table.customerTable);
          CheckForTable("productType", table.productTypeTable);
          CheckForTable("paymentType", table.paymentTypeTable);
          CheckForTable("[order]", table.orderTable);                  // order is in [] to avoid conflicts with reserved word
          CheckForTable("product", table.productTable);
          CheckForTable("orderProduct", table.orderProductTable);
        }

        // checks for table name passed, and executes SQL statement to create the table if table doesn't exist
        public void CheckForTable (string tableName, string SQLstatement)              // pass table name, SQL statement to create it
        {
            using (_connection)
            {
                _connection.Open();
                SqliteCommand dbcmd = _connection.CreateCommand ();

                // Query if the passed table has been created
                dbcmd.CommandText = $"select id from {tableName}";                     // does table "tableName" exist?

                try
                {
                    // Try running query. If exception, create the table according to the name and SQL statement passed
                    using (SqliteDataReader reader = dbcmd.ExecuteReader()) { }
                    dbcmd.Dispose ();
                }
                catch (Microsoft.Data.Sqlite.SqliteException ex)
                {
                    Console.WriteLine(ex.Message);
                    if (ex.Message.Contains("no such table"))
                    {
                        Console.WriteLine(SQLstatement);
                        dbcmd.CommandText = SQLstatement;                  // SQLstatement passed in here to write X table
                        try
                        {
                            dbcmd.ExecuteNonQuery ();
                        }
                        catch (Microsoft.Data.Sqlite.SqliteException crex)
                        {
                            Console.WriteLine("Tried to make a table, and failed.");
                        }
                        dbcmd.Dispose ();
                    }
                }
                _connection.Close ();
            }
        }

        // If Toy method is below, it is ONLY FOR TESTING to see if Db file gets written before Andy completes the variable to get passed into the above method

    }
}