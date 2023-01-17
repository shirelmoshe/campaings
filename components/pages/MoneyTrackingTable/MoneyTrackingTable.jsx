import React, { useState, useEffect } from "react";
import { getMoneyTrackingTable } from "../../servers/servers";
import { MoneyTrackingTableCard } from "../../MoneyTrackingTableCard/MoneyTrackingTableCard";

export const MoneyTrackingTable = () => {
  const [MoneyTrackingTable, setMoneyTrackingTable] = useState([]);

  const initTwitterTableInfo = async () => {
    let response = await getMoneyTrackingTable();
    if (response && typeof response === "object") {
      let CampaignsArr = Object.values(response);
      setMoneyTrackingTable(CampaignsArr);
    } else {
      console.log("error");
    }
  };

  useEffect(() => {
    initTwitterTableInfo();
  }, []);

  return (
    <>
      {MoneyTrackingTable &&
        MoneyTrackingTable.map((response) => {
          const { user_id, associationName, hashtag, userName, userMoney } =
            response;
          return (
            <>
              <table class="table table-striped">
                <thead className="table table-striped">
                  <tr>
                    <th scope="col">associationName</th>
                    <th scope="col">hashtag</th>
                    <th scope="col">userName</th>
                    <th scope="col">userMoney</th>
                  </tr>
                </thead>

                <MoneyTrackingTableCard
                  key={user_id}
                  associationName={associationName}
                  hashtag={hashtag}
                  userName={userName}
                  userMoney={userMoney}
                ></MoneyTrackingTableCard>
              </table>
            </>
          );
        })}
    </>
  );
};
