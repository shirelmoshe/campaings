using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectCampaigns.Dal;
using ProjectCampaigns.data.sql;
using ProjectCampaigns.Model;

namespace ProjectCampaigns.Entities
{
    public class users
    {
        Dictionary<int, user> dictionsryUser= new Dictionary<int, user>();
        string connectionString = "Integrated Security = SSPI; Persist Security Info=False;Initial Catalog = campaign ; Data Source = localhost\\sqlEXPRESS";
        public void CreateUsers(string userName, string cellphoneNumber, string email, string UserType, string twitterUsername,string user_id)
        {
            // Define the insert statement
            string insert = "insert into Usertable (userName, cellphoneNumber, twitterUsername, email, UserType,user_id) OUTPUT INSERTED.userId values (@userName, @cellphoneNumber, @twitterUsername, @email, @UserType,@user_id)";

            try
            {
                // Open a connection to the database
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    // Create a command with the insert statement and the connection
                    using (SqlCommand command = new SqlCommand(insert, connection))
                    {
                        if (string.IsNullOrWhiteSpace(userName))
                            throw new ArgumentException("userName cannot be null or empty", nameof(userName));
                        if (string.IsNullOrWhiteSpace(twitterUsername))
                            throw new ArgumentException("twitterUsername cannot be null or empty", nameof(twitterUsername));
                        // Open the connection
                        connection.Open();

                        // Add the user message data as parameters to the command
                        command.Parameters.AddWithValue("@userName", userName);
                        command.Parameters.AddWithValue("@cellphoneNumber", cellphoneNumber);
                        command.Parameters.AddWithValue("@twitterUsername", twitterUsername);
                        command.Parameters.AddWithValue("@email", email);
                        command.Parameters.AddWithValue("@UserType", UserType);
                        command.Parameters.AddWithValue("@user_id", user_id);

                        int userId = (int)command.ExecuteScalar();
                        // Execute the command
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (SqlException ex)
            {
                // Handle SQL exceptions
                Console.WriteLine("Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                // Handle other exceptions
            }
        }



        public Dictionary<int, user> UserDetailsfromSQL()
        {
            try
            {
                Dictionary<int, user> ret;
                campaingSql.LoadingCampingsDetails("select * from Usertable", ReadUsersFromDb);

                return dictionsryUser;
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                return null;
            }



        }


        public void ReadUsersFromDb(SqlDataReader reader)
        {

            //Clear Dictionary Before Inserting Information From Sql Server
            dictionsryUser.Clear();


            while (reader.Read())
            {
                user readUser = new user();

                readUser.userId = reader.GetInt32(0);
                readUser.userName = reader.GetString(1);
                readUser.cellphoneNumber = reader.GetString(2);
                readUser.email = reader.GetString(3);
                readUser.UserType = reader.GetString(4);


                //Cheking If Hashtable contains the key
                if (dictionsryUser.ContainsKey(readUser.userId))
                {
                    //key already exists
                }
                else
                {
                    //Filling a hashtable
                    dictionsryUser.Add(readUser.userId, readUser);
                }


               

            }


        }
        public user GetUserSocialActivistFromDbById(string id)
        {
            data.sql.campaingSql userFromSql = new data.sql.campaingSql();
            user socialActivistNew = (user)userFromSql.LoadOneSocialActivist(id);
            return socialActivistNew;
        }

    }

}

