using NLog;
using ProjectCampaigns.Dal;
using ProjectCampaigns.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using static ProjectCampaigns.Dal.SqlQuery;

namespace ProjectCampaigns.data.sql
{
    public class campaingSql

    {

        private static readonly Logger logger = LogManager.GetCurrentClassLogger();

        public static string connectionString = "Integrated Security = SSPI; Persist Security Info=False;Initial Catalog = campaign ; Data Source = localhost\\sqlEXPRESS";

        public Dictionary<int, Campaign> AddCampaingToDictionary(SqlDataReader reader)
        {
            logger.Info("AddCampaingToDictionary function called with SqlDataReader: {0}", reader);
            //Create a dictionary that will contain the products data. The key of the dictionary is the product's ID and the value is the Product object
            Dictionary<int, Campaign> dictionsryCampaing = new Dictionary<int, Campaign>();

            //Clear the dictionary before adding new products.
            dictionsryCampaing.Clear();

            while (reader.Read())
            {
                Campaign readCampaign = new Campaign();

                readCampaign.usreId = reader.GetInt32(reader.GetOrdinal("ProductID"));
                readCampaign.associationName = reader.GetString(reader.GetOrdinal("associationName"));
                readCampaign.email = reader.GetString(reader.GetOrdinal("email"));
                readCampaign.uri = reader.GetString(reader.GetOrdinal("uri"));
                readCampaign.hashtag = reader.GetString(reader.GetOrdinal("hashtag"));




                //Add the new Product object to the dictionary
                dictionsryCampaing.Add(readCampaign.usreId, readCampaign);
            }

            return dictionsryCampaing;
        }

        public static void LoadingCampingsDetails(string SqlQuery, SetDataReader_delegate1 Ptrfunc)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string queryString = SqlQuery;

                    // Adapter
                    using (SqlCommand command = new SqlCommand(queryString, connection))
                    {
                        connection.Open();
                        //Reader
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            Ptrfunc(reader);

                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                logger.Error(ex, "SQL exception occurred: {0}", ex.Message);
                // log the error message
                NLog.Fluent.Log.Error(ex.Message);
                throw;
            }
            catch (Exception ex)
            {
                logger.Error(ex, "Exception occurred: {0}", ex.Message);

                // log the error message
               
                throw;
            }
        }




        public Dictionary<int, Donation> Add2cToDictionary(SqlDataReader reader)
        {
            logger.Info("Add2cToDictionary function called with SqlDataReader: {0}", reader);
            //Create a dictionary that will contain the products data. The key of the dictionary is the product's ID and the value is the Product object
            Dictionary<int, Donation> dictionsryProducts = new Dictionary<int, Donation>();

            //Clear the dictionary before adding new products.
            dictionsryProducts.Clear();

            while (reader.Read())
            {
                Donation readProducts = new Donation();

                readProducts.productsId = reader.GetInt32(reader.GetOrdinal("productsId"));
                readProducts.CampaignName = reader.GetString(reader.GetOrdinal("CampaignName"));
                readProducts.Product = reader.GetString(reader.GetOrdinal("Product"));
                readProducts.Email = reader.GetString(reader.GetOrdinal("Email"));
                readProducts.Price = reader.GetString(reader.GetOrdinal("Price"));




                //Add the new Product object to the dictionary
                dictionsryProducts.Add(readProducts.productsId, readProducts);
            }

            return dictionsryProducts;
        }

        public object LoadOneProduct(int productsId)
        {
            logger.Info("LoadOneProduct function called with productsId: {0}", productsId);

            // Define the SELECT statement that will be used to retrieve the product data
            string select = "select * from Donation where productsId = @productsId";

            // Create a new product object
            Donation product = new Donation();

            try
            {
                // Create a new connection to the database
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Create a new command that will be used to execute the SELECT statement
                    using (SqlCommand command = new SqlCommand(select, connection))
                    {
                        // Open the connection
                        connection.Open();

                        // Add the product ID parameter to the SELECT statement
                        command.Parameters.AddWithValue("@productsId", productsId);

                        // Execute the SELECT statement and get the result set
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // Read the result set
                            while (reader.Read())
                            {
                                // Set the values of the product object with the data from the result set
                                product.productsId = reader.GetInt32(reader.GetOrdinal("productsId"));
                                product.CampaignName = reader.GetString(reader.GetOrdinal("CampaignName"));
                                product.Product = reader.GetString(reader.GetOrdinal("Product"));
                                product.Email = reader.GetString(reader.GetOrdinal("Email"));
                                product.Price = reader.GetString(reader.GetOrdinal("Price"));
                            }
                        }
                    }
                }
            }
            // Catch any SQL exceptions that may occur and write the error message to the console
            catch (SqlException ex)
            {
                logger.Error(ex, "SQL exception occurred: {0}", ex.Message);
                Console.WriteLine(ex.Message);
                throw;
            }
            // Catch any other exceptions that may occur and write the error message to the console
            catch (Exception ex)
            {
                logger.Error(ex, "Exception occurred: {0}", ex.Message);

                Console.WriteLine(ex.Message);
                throw;
            }

            // Return the product object
            return product;
        }




        public object LoadOneAssociation(int userId)
        {
            logger.Info("LoadOneAssociation function called with userId: {0}", userId);

            // Define the SELECT statement that will be used to retrieve the product data
            string select = "select * from Usertable where userId = @userId";

            // Create a new product object
            association association = new association();

            try
            {
                // Create a new connection to the database
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Create a new command that will be used to execute the SELECT statement
                    using (SqlCommand command = new SqlCommand(select, connection))
                    {
                        // Open the connection
                        connection.Open();

                        // Add the product ID parameter to the SELECT statement
                        command.Parameters.AddWithValue("@userId", userId);

                        // Execute the SELECT statement and get the result set
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // Read the result set
                            while (reader.Read())
                            {



                                // Set the values of the product object with the data from the result set
                                association.userId = reader.GetInt32(reader.GetOrdinal("userId"));
                                association.userName = reader.GetString(reader.GetOrdinal("userName"));
                                association.cellphoneNumber = reader.GetString(reader.GetOrdinal("cellphoneNumber"));
                                association.email = reader.GetString(reader.GetOrdinal("email"));
                                association.UserType = reader.GetString(reader.GetOrdinal("UserType"));
                            }
                        }
                    }
                }
            }
            // Catch any SQL exceptions that may occur and write the error message to the console
            catch (SqlException ex)
            {
                logger.Error(ex, "SQL exception occurred: {0}", ex.Message);

                Console.WriteLine(ex.Message);
                throw;
            }
            // Catch any other exceptions that may occur and write the error message to the console
            catch (Exception ex)
            {
                logger.Error(ex, "Exception occurred: {0}", ex.Message);

                Console.WriteLine(ex.Message);
                throw;
            }

            // Return the product object
            return association;
        }


        public List<sale> LoadSales(int userId)
        {
            logger.Info("LoadSales function called with userId: {0}", userId);
            // Define the SELECT statement that will be used to retrieve the product data
            string select = "SELECT [buyerName],[Salese].[cellphoneNumber], [dbo].[Donation].[Email],[buyerAddress], [dbo].[Donation].[CompanyName], [Product], [Price], [CampaignName],getDate() as DATE FROM [dbo].[Donation] \r\nJOIN [dbo].[Salese] ON [dbo].[Donation].[CompanyName] = [dbo].[Salese].[CompanyName]\r\nJOIN Users ON [Donation].[Email]=Users.[email]\r\nWHERE [userId] = @userId";

            // Create a new product object
            List<sale> sales = new List<sale>();

            try
            {
                // Create a new connection to the database
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Create a new command that will be used to execute the SELECT statement
                    using (SqlCommand command = new SqlCommand(select, connection))
                    {
                        // Open the connection
                        connection.Open();

                        // Add the product ID parameter to the SELECT statement
                        command.Parameters.AddWithValue("@userId", userId);

                        // Execute the SELECT statement and get the result set
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // Read the result set
                            while (reader.Read())
                            {
                                sale sale = new sale();
                                sale.buyerName = reader.GetString(reader.GetOrdinal("buyerName"));
                                sale.cellphoneNumber = reader.GetString(reader.GetOrdinal("cellphoneNumber"));
                                sale.Email = reader.GetString(reader.GetOrdinal("Email"));
                                sale.buyerAddress = reader.GetString(reader.GetOrdinal("buyerAddress"));
                                sale.CompanyName = reader.GetString(reader.GetOrdinal("CompanyName"));
                                sale.Product = reader.GetString(reader.GetOrdinal("Product"));
                                sale.Price = reader.GetString(reader.GetOrdinal("Price"));
                                sale.CampaignName = reader.GetString(reader.GetOrdinal("CampaignName"));
                                sale.DATE = reader.GetDateTime(reader.GetOrdinal("DATE"));
                                sales.Add(sale);
                            }
                        }
                    }
                }
            }
            // Catch any SQL exceptions that may occur and write the error message to the console
            catch (SqlException ex)
            {
                logger.Error(ex, "SQL exception occurred: {0}", ex.Message);
                Console.WriteLine(ex.Message);
                throw;
            }
            // Catch any other exceptions that may occur and write the error message to the console
            catch (Exception ex)
            {
                logger.Error(ex, "Exception occurred: {0}", ex.Message);

                Console.WriteLine(ex.Message);
                throw;
            }

            // Return the product object
            return sales;
        }







        public object LoadOneSocialActivist(string user_id)
        {
            logger.Info("LoadOneSocialActivist function called with user_id: {0}", user_id);
            // Define the SELECT statement that will be used to retrieve the product data.
            string select = "select * from Usertable where user_id = @user_id";

            // Create a new product object
            user user = new user();

            try
            {
                // Create a new connection to the database
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Create a new command that will be used to execute the SELECT statement
                    using (SqlCommand command = new SqlCommand(select, connection))
                    {
                        // Open the connection
                        connection.Open();

                        // Add the product ID parameter to the SELECT statement
                        command.Parameters.AddWithValue("@user_id", user_id);

                        // Execute the SELECT statement and get the result set
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // Read the result set
                            while (reader.Read())
                            {



                                // Set the values of the product object with the data from the result set
                                
                                user.userName = reader.GetString(reader.GetOrdinal("userName"));
                                user.cellphoneNumber = reader.GetString(reader.GetOrdinal("cellphoneNumber"));
                                user.email = reader.GetString(reader.GetOrdinal("email"));
                                user.UserType = reader.GetString(reader.GetOrdinal("UserType"));
                                user.user_id = reader.GetString(reader.GetOrdinal("user_id"));
                            }
                        }
                    }
                }
            }
            // Catch any SQL exceptions that may occur and write the error message to the console
            catch (SqlException ex)
            {
                logger.Error(ex, "SQL exception occurred: {0}", ex.Message);
                Console.WriteLine(ex.Message);
                throw;
            }
            // Catch any other exceptions that may occur and write the error message to the console
            catch (Exception ex)
            {
                logger.Error(ex, "Exception occurred: {0}", ex.Message);

                Console.WriteLine(ex.Message);
                throw;
            }

            // Return the product object
            return user;
        }


        public List<moneyTracking> LoadAllmoneyTrackings(string user_id)
        {
            logger.Info("LoadAllmoneyTrackings function called with user_id: {0}", user_id);
            // Define the SELECT statement that will be used to retrieve the product data.
            string select = "select [user_id],[associationName],[hashtag],[dbo].[Twitter].[userName],[userMoney]from [dbo].[Twitter] inner join [dbo].[Usertable] on [dbo].[Usertable].[email]=[dbo].[Twitter].[email] where [user_id]=@user_id";

            // Create a new list to store the moneyTracking objects
            List<moneyTracking> moneyTrackings = new List<moneyTracking>();

            try
            {
                // Create a new connection to the database
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Create a new command that will be used to execute the SELECT statement
                    using (SqlCommand command = new SqlCommand(select, connection))
                    {
                        // Open the connection
                        connection.Open();

                        // Add the user_id parameter to the SELECT statement
                        command.Parameters.AddWithValue("@user_id", user_id);

                        // Execute the SELECT statement and get the result set
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            // Read the result set
                            while (reader.Read())
                            {
                                // Create a new moneyTracking object
                                moneyTracking moneyTracking = new moneyTracking();
                                // Set the values of the moneyTracking object with the data from the result set
                                moneyTracking.user_id = reader.GetString(reader.GetOrdinal("user_id"));
                                moneyTracking.associationName = reader.GetString(reader.GetOrdinal("associationName"));
                                moneyTracking.hashtag = reader.GetString(reader.GetOrdinal("hashtag"));
                                moneyTracking.userName = reader.GetString(reader.GetOrdinal("userName"));
                                moneyTracking.userMoney = reader.GetInt32(reader.GetOrdinal("userMoney"));
                                // Add the moneyTracking object to the list
                                moneyTrackings.Add(moneyTracking);
                            }
                        }
                    }
                }
            }
            // Catch any SQL exceptions that may occur and write the error message to the console
            catch (SqlException ex)
            {
                logger.Error(ex, "SQL exception occurred: {0}", ex.Message);
                Console.WriteLine(ex.Message);
                throw;
            }
            // Catch any other exceptions that may occur and write the error message to the console
            catch (Exception ex)
            {
                logger.Error(ex, "Exception occurred: {0}", ex.Message);

                Console.WriteLine(ex.Message);
                throw;
            }

            // Return the list of moneyTracking objects
            return moneyTrackings;
        }


    }
}
