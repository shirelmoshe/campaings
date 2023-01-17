import React from "react";
import "./r.css";
import { useState } from "react";
import { addSale } from "./../servers/servers";

export const ProductData = ({ CampaignName, Product, Price, productsId }) => {
  console.log(` ProductName : ${CampaignName}`);
  console.log(` unitsInStock : ${Product}`);
  const [userMessage, setUserMessage] = useState({
    buyerName: "",
    cellphoneNumber: "",
    Email: "",
    buyerAddress: "",
    CompanyName: "",
  });

  const handleAddMessage = async () => {
    let json = userMessage;
    await addSale(json);
    setUserMessage({});
    document.querySelectorAll("input").forEach((input) => (input.value = ""));
  };

  return (
    <>
      <div className="card">
        <div className="card product-container">
          <div className="card-body">
            <h2 className="card-title">{Product}</h2>
            <h5>Unit Price: {Price}</h5>
            <h5>CompanyName: {CampaignName}</h5>
          </div>
          <div className="input-group mb-3">
            <span className="input-group-text">name</span>
            <input
              className="form-control"
              type="text"
              onChange={(o) => {
                setUserMessage({ ...userMessage, buyerName: o.target.value });
              }}
            />
          </div>
          <div className="input-group mb-3">
            <span className="input-group-text">cellphone Number</span>
            <input
              className="form-control"
              type="text"
              onChange={(o) => {
                setUserMessage({
                  ...userMessage,
                  cellphoneNumber: o.target.value,
                });
              }}
            />
          </div>
          <div className="input-group mb-3">
            <span className="input-group-text">Email</span>
            <input
              className="form-control"
              type="text"
              onChange={(o) => {
                setUserMessage({ ...userMessage, Email: o.target.value });
              }}
            />
          </div>
          <div className="input-group mb-3">
            <span className="input-group-text">Address</span>
            <input
              className="form-control"
              type="text"
              onChange={(o) => {
                setUserMessage({
                  ...userMessage,
                  buyerAddress: o.target.value,
                });
              }}
            />
          </div>
          <div className="input-group mb-3">
            <span className="input-group-text">CompanyName</span>
            <input
              className="form-control"
              type="text"
              onChange={(o) => {
                setUserMessage({
                  ...userMessage,
                  CompanyName: o.target.value,
                });
              }}
            />
          </div>
        </div>
        <button className="btn btn-secondary" onClick={handleAddMessage}>
          Send
        </button>
      </div>
    </>
  );
};
