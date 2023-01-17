import React, { useState, useEffect } from "react";
import { getUsersData } from "../../servers/servers";
import { CardUser } from "../../UserCard/userCard";

export const UsersTable = () => {
  const [UserInfo, setUserInfo] = useState([]);

  const initSalesInfo = async () => {
    let response = await getUsersData();
    if (response && typeof response === "object") {
      let UserArr = Object.values(response);
      setUserInfo(UserArr);
    } else {
      console.log("error");
    }
  };

  useEffect(() => {
    initSalesInfo();
  }, []);

  return (
    <>
      {UserInfo &&
        UserInfo.map((response) => {
          const { userId, userName, cellphoneNumber, email, UserType } =
            response;
          return (
            <>
              <table class="table table-striped">
                <thead className="table">
                  <tr>
                    <th scope="col"> userId</th>
                    <th scope="col">userName</th>
                    <th scope="col">cellphoneNumber</th>
                    <th scope="col">email</th>
                    <th scope="col">UserType</th>
                  </tr>
                </thead>
                return (
                <CardUser
                  userId={userId}
                  userName={userName}
                  cellphoneNumber={cellphoneNumber}
                  email={email}
                  UserType={UserType}
                ></CardUser>
                )
              </table>
            </>
          );
        })}
    </>
  );
};
