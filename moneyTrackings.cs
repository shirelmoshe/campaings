using ProjectCampaigns.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCampaigns.Entities
{
    public class moneyTrackings
    {

        public List<moneyTracking> GetmoneyTrackingsFromDbById(string id)
        {
            data.sql.campaingSql userFromSql = new data.sql.campaingSql();
            List<moneyTracking> moneyTrackingsList = userFromSql.LoadAllmoneyTrackings(id);
            return moneyTrackingsList;
        }

    }
}
