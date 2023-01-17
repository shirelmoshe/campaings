import React from "react";

export const CardUser = ({
  userId,
  userName,
  cellphoneNumber,
  email,
  UserType,
}) => {
  return (
    <>
      <tr>
        <td>{userId}</td>
        <td>{userName}</td>
        <td>{cellphoneNumber}</td>
        <td>{email}</td>
        <td>{UserType}</td>
      </tr>
    </>
  );
};
