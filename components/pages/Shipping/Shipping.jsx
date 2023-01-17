import React, { useState, useEffect } from "react";
import { getShipping } from "../../servers/servers";
import { ShippingCard } from "../../ShippingCard/ShippingCard";

export const Shipping = () => {
  const [SalesInfo, setSalesInfo] = useState([]);

  const initSalesInfo = async () => {
    let response = await getShipping();
    if (response && typeof response === "object") {
      let CampaignsArr = Object.values(response);
      setSalesInfo(CampaignsArr);
    } else {
      console.log("error");
    }
  };

  useEffect(() => {
    initSalesInfo();
  }, []);

  return (
    <>
      {SalesInfo &&
        SalesInfo.map((response) => {
          const {
            productsId,
            buyerName,
            cellphoneNumber,
            Email,
            buyerAddress,
            CompanyName,
            Product,
            Price,
            CampaignName,
          } = response;
          return (
            <>
              <table class="table table-striped">
                <thead className="table table-striped">
                  <tr>
                    <th scope="col">buyer Name</th>
                    <th scope="col">cellphone Number</th>
                    <th scope="col">Email</th>
                    <th scope="col">buyer Address</th>
                    <th scope="col">Company Name</th>
                    <th scope="col">Product</th>
                    <th scope="col">Price</th>
                    <th scope="col">CampaignName</th>
                  </tr>
                </thead>

                <ShippingCard
                  productsId={productsId}
                  buyerName={buyerName}
                  cellphoneNumber={cellphoneNumber}
                  Email={Email}
                  buyerAddress={buyerAddress}
                  CompanyName={CompanyName}
                  Product={Product}
                  Price={Price}
                  CampaignName={CampaignName}
                ></ShippingCard>
              </table>
            </>
          );
        })}
    </>
  );
};
