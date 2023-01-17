import React from "react";
import "./Card.css";

export const CardSales = ({
  ProductID,
  buyerName,
  Email,
  cellphoneNumber,
  buyerAddress,
  CompanyName,
  Product,
  Price,
  CampaignName,
  DATE,
}) => {
  return (
    <>
      <tr>
        <td>{ProductID}</td>
        <td>{buyerName}</td>
        <td>{cellphoneNumber}</td>
        <td>{Email}</td>
        <td>{buyerAddress}</td>
        <td>{CompanyName}</td>
        <td>{Product}</td>
        <td>{Price}</td>
        <td>{CampaignName}</td>
      </tr>
    </>
  );
};
