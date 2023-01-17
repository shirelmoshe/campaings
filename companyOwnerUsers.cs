using ProjectCampaigns.Dal;
using ProjectCampaigns.Model;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCampaigns.Entities
{
    public  class companyOwnerUsers
    {
        public List<companyOwnerUser> CompanyOwnerUser { get; set; }

        string insert2 = "select ompanyName,userName,amountOfDonations from companyOwnerUsers";
        public List<companyOwnerUser> getCompanyOwnerUser()
        {
            SqlQuery query = new SqlQuery();

         
            bool isConnected = query.Connect();
            if (isConnected)
            {
                
                query.runCommand1(insert2, addOwnerUsers);
            }
         
           
            return CompanyOwnerUser;
        }
        
        public void addOwnerUsers(System.Data.SqlClient.SqlDataReader reader)
        {
            CompanyOwnerUser = new List<companyOwnerUser>();
            while (reader.Read())
            {
                companyOwnerUser company_Owner_User = new companyOwnerUser() { companyName = reader["companyName"].ToString(), userName = reader["userName"].ToString(), amountOfDonations = int.Parse(reader["amountOfDonations"].ToString()) };
                CompanyOwnerUser.Add(company_Owner_User);
            }


        }
       


    }
}
