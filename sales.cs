﻿using ProjectCampaigns.data.sql;
using ProjectCampaigns.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCampaigns.Entities
{
    public class sales
    {
        string connectionString = "Integrated Security = SSPI; Persist Security Info=False;Initial Catalog = campaign ; Data Source = localhost\\sqlEXPRESS";
        public void InsertnewSaleseToDb(string buyerName, string cellphoneNumber, string Email, string buyerAddress, string CompanyName)
        {
            // SQL insert statement to insert a new row into the Donation table
            string insert = "insert into Salese values (@buyerName,@cellphoneNumber,@Email,@buyerAddress ,@CompanyName)";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    using (SqlCommand command = new SqlCommand(insert, connection))
                    {
                        connection.Open();

                        // Add the donation data as parameters to the command
                        command.Parameters.AddWithValue("@buyerName", buyerName);
                        command.Parameters.AddWithValue("@cellphoneNumber", cellphoneNumber);
                        command.Parameters.AddWithValue("@Email", Email);
                        command.Parameters.AddWithValue("@buyerAddress", buyerAddress);
                        command.Parameters.AddWithValue("@CompanyName", CompanyName);

                        // Execute the command
                        command.ExecuteNonQuery();
                        int productNumber = 1; // product number you want to check
                        int userMoney;
                        int price;

                        // Use a SqlCommand to execute the SELECT query
                        using (SqlCommand selectCommand = new SqlCommand("SELECT [Price], [BuyerName], [CampaignName], [Twitter].[userMoney] " +
                                                                         "FROM [dbo].[Sales] " +
                                                                         "INNER JOIN [dbo].[Donation] " +
                                                                         "ON [dbo].[Donation].[productsId] = [dbo].[Sales].[Product_Number] " +
                                                                         "INNER JOIN [dbo].[Twitter] " +
                                                                         "ON [dbo].[Twitter].[email] = [dbo].[Sales].[Email] " +
                                                                         "WHERE [dbo].[Sales].[Product_Number] = @Product_Number", connection))
                        {
                            selectCommand.Parameters.AddWithValue("@Product_Number", productNumber);

                // Use a SqlConnection and SqlCommand to execute the insert statement

                    using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    price = (int)reader["Price"];
                                    userMoney = (int)reader["userMoney"];
                                    if (userMoney > price)
                                    {
                                        userMoney -= price;
                                        // Use a new SqlCommand to execute the update statement
                                        using (SqlCommand updateCommand = new SqlCommand("UPDATE [dbo].[Twitter] " +
                                                                                        "SET [userMoney] = @userMoney " +
                                                                                        "WHERE [email] = @email", connection))
                                        {
                                            updateCommand.Parameters.AddWithValue("@userMoney", userMoney);
                                            updateCommand.Parameters.AddWithValue("@email", reader["Email"]);
                                            updateCommand.ExecuteNonQuery();
                                        }
                                    }
                                }
                            }
                        }   }

                    }

                    }
            catch (SqlException ex)
            {
                // Handle SQL exceptions
                Console.WriteLine(ex.Message);
            }
            catch (Exception ex)
            {
                // Handle other exceptions
                Console.WriteLine(ex.Message);
            }
        }

        public Dictionary<int, sale> salesDetailsfromSQL()
        {
            try
            {
                // Call the LoadingCampingsDetails method to execute the SQL query
                // and pass the ReadbusinessOwnerDetailsFromDb method as a callback
                campaingSql.LoadingCampingsDetails("select [Product_Number],[buyerName],[cellphoneNumber],[dbo].[Donation].[Email],[buyerAddress],[dbo].[Donation].[CompanyName],[Product],[Price],[CampaignName],getDate()  as DATE FROM \r\n[dbo].[Donation] JOIN [dbo].[Salese] ON [dbo].[Donation].[CompanyName] = [dbo].[Salese].[CompanyName]", ReadSalesDetailsFromDb);

                // Return the dictionary of business owners
                return dictionsrySales;
            }
            catch (Exception ex)
            {
                // Print the exception message if an error occurs
                Console.WriteLine(ex.Message);
                return null;
            }
        }









        Dictionary<int, sale> dictionsrySales = new Dictionary<int, sale>();

        // Method to process the retrieved data and fill the dictionary with business owner objects
        public void ReadSalesDetailsFromDb(SqlDataReader reader)
        {
            try
            {
                // Clear the dictionary before inserting data from the database
                dictionsrySales.Clear();

                // Read each row in the data reader
                while (reader.Read())
                {
                    // Create a new businessOwner object
                    sale readDictionsrySalesDetails = new sale();

                    // Initialize the fields of the businessOwner object with data from the database
                    readDictionsrySalesDetails.productsId = reader.GetInt32(0);
                    readDictionsrySalesDetails.buyerName = reader.GetString(1);
                    readDictionsrySalesDetails.cellphoneNumber = reader.GetString(2);
                    readDictionsrySalesDetails.Email = reader.GetString(3);
                    readDictionsrySalesDetails.buyerAddress = reader.GetString(4);

                    readDictionsrySalesDetails.CompanyName = reader.GetString(5);
                    readDictionsrySalesDetails.Product = reader.GetString(6);
                    readDictionsrySalesDetails.Price = reader.GetString(7);
                    readDictionsrySalesDetails.CampaignName = reader.GetString(8);
                    readDictionsrySalesDetails.DATE = reader.GetDateTime(9);
                    // Check if the dictionary already contains a business owner with the same userId
                    if (dictionsrySales.ContainsKey(readDictionsrySalesDetails.productsId))
                    {
                        // Key already exists, log a warning message
                        Console.WriteLine("Warning: Dictionary already contains business owner with userId: " + readDictionsrySalesDetails.productsId);
                    }
                    else
                    {
                        // Add the business owner object to the dictionary
                        dictionsrySales.Add(readDictionsrySalesDetails.productsId, readDictionsrySalesDetails);
                    }
                }
            }
            catch (Exception ex)
            {
                //




            }
        }



        public Dictionary<int, sale> shippingDetailsfromSQL()
        {
            try
            {
                // Call the LoadingCampingsDetails method to execute the SQL query
                // and pass the ReadbusinessOwnerDetailsFromDb method as a callback
                campaingSql.LoadingCampingsDetails(" SELECT [Product_Number], [buyerName], [cellphoneNumber], [dbo].[Donation].[Email],\r\n[buyerAddress], [dbo].[Donation].[CompanyName], [Product], [Price], [CampaignName],\r\ngetDate() as DATE FROM [dbo].[Donation] JOIN [dbo].[Salese] ON [dbo].[Donation].[CompanyName] = [dbo].[Salese].[CompanyName] \r\nWHERE [productsId] = '@productsId'", shippingDetailsfromSQL);

                // Return the dictionary of business owners
                return dictionsrySales;
            }
            catch (Exception ex)
            {
                // Print the exception message if an error occurs
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        Dictionary<int, sale> shippingDictionry = new Dictionary<int, sale>();

        // Method to process the retrieved data and fill the dictionary with business owner objects
        public void shippingDetailsfromSQL(SqlDataReader reader)
        {
            try
            {
                // Clear the dictionary before inserting data from the database
                shippingDictionry.Clear();

                // Read each row in the data reader
                while (reader.Read())
                {
                    // Create a new businessOwner object
                    sale readShippingDictionryDetails = new sale();

                    // Initialize the fields of the businessOwner object with data from the database
                    readShippingDictionryDetails.productsId = reader.GetInt32(0);
                    readShippingDictionryDetails.buyerName = reader.GetString(1);
                    readShippingDictionryDetails.cellphoneNumber = reader.GetString(2);
                    readShippingDictionryDetails.Email = reader.GetString(3);
                    readShippingDictionryDetails.buyerAddress = reader.GetString(4);
                    readShippingDictionryDetails.buyerAddress = reader.GetString(5);
                    readShippingDictionryDetails.CompanyName = reader.GetString(6);
                    readShippingDictionryDetails.Product = reader.GetString(7);
                    readShippingDictionryDetails.Price = reader.GetString(8);
                    readShippingDictionryDetails.CampaignName = reader.GetString(9);
                    readShippingDictionryDetails.DATE = reader.GetDateTime(10);
                    // Check if the dictionary already contains a business owner with the same userId
                    if (shippingDictionry.ContainsKey(readShippingDictionryDetails.productsId))
                    {
                        // Key already exists, log a warning message
                        Console.WriteLine("Warning: Dictionary already contains business owner with userId: " + readShippingDictionryDetails.productsId);
                    }
                    else
                    {
                        // Add the business owner object to the dictionary
                        shippingDictionry.Add(readShippingDictionryDetails.productsId, readShippingDictionryDetails);
                    }
                }
            }
            catch (Exception ex)
            {
                //




            }









        }
        public List<sale> GetSaleFromDbById(int id)
        {
            data.sql.campaingSql userFromSql = new data.sql.campaingSql();
            return userFromSql.LoadSales(id);
        }
    }
}
