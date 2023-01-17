import React, { useState, useEffect } from "react";
import { getCampaingsTable } from "../../servers/servers";

import { CardCampings } from "../../CampaingsTableCard/CampaingsTableCard";
export const CampaingsTable = () => {
  const [CampaingsTable, setCampaingsTable] = useState([]);

  const initSalesInfo = async () => {
    let response = await getCampaingsTable();
    if (response && typeof response === "object") {
      let CampaignsArr = Object.values(response);
      setCampaingsTable(CampaignsArr);
    } else {
      console.log("error");
    }
  };

  useEffect(() => {
    initSalesInfo();
  }, []);

  return (
    <>
      {CampaingsTable &&
        CampaingsTable.map((response) => {
          const { usreId, associationName, email, uri, hashtag, CampaignName } =
            response;
          return (
            <>
              <table class="table table-striped">
                <thead className="table table-striped">
                  <tr>
                    <th scope="col">associationName</th>
                    <th scope="col">email</th>
                    <th scope="col">uri</th>
                    <th scope="col">hashtag</th>
                    <th scope="col">CampaignName</th>
                  </tr>
                </thead>

                <CardCampings
                  key={usreId}
                  associationName={associationName}
                  email={email}
                  uri={uri}
                  hashtag={hashtag}
                  CampaignName={CampaignName}
                ></CardCampings>
              </table>
            </>
          );
        })}
    </>
  );
};
