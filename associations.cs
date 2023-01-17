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
    public  class associations
    {

       
        
            // Dictionary to store business owner objects, using the userId as the key
        

            // Method to process the retrieved data and fill the dictionary with business owner objects
           

        public association GetUserFromDbById(int id)
        {
            data.sql.campaingSql userFromSql = new data.sql.campaingSql();
            association associationtNew = (association)userFromSql.LoadOneAssociation(id);
            return associationtNew;
        }


      

    }
}
