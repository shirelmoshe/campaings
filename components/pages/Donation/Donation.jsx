import React, { useState } from "react";
import { addDonation } from "../../servers/servers";
import "./Donation.css";

export const Donation = (props) => {
  const [userMessage, setUserMessage] = useState({
    CompanyName: "",
    Product: "",
    CampaignName: "",
    Price: "",
    Email: "",
    Quantity: "",
  });
  const handleAddMessage = async () => {
    let json = { ...userMessage };
    await addDonation(json);
    setUserMessage({});
    document.querySelectorAll("input").forEach((input) => (input.value = ""));
  };

  return (
    <>
      <div className="input-group mb-3">
        <span className="input-group-text">CompanyName</span>
        <input
          className="form-control"
          type="text"
          onChange={(o) => {
            setUserMessage({ ...userMessage, CompanyName: o.target.value });
          }}
        />
      </div>
      <div className="input-group mb-3">
        <span className="input-group-text">Product</span>
        <input
          className="form-control"
          type="text"
          onChange={(o) => {
            setUserMessage({ ...userMessage, Product: o.target.value });
          }}
        />
      </div>
      <div className="input-group mb-3">
        <span className="input-group-text"> Email </span>
        <input
          className="form-control"
          type="email"
          onChange={(o) => {
            setUserMessage({ ...userMessage, Email: o.target.value });
          }}
        />
      </div>
      <div className="input-group mb-3">
        <span className="input-group-text">Price:</span>
        <input
          className="form-control"
          type="text"
          onChange={(o) => {
            setUserMessage({ ...userMessage, Price: o.target.value });
          }}
          onKeyDown={(o) => {
            if (o.target.value.length >= 300) {
              o.preventDefault();
            }
          }}
        />
        <div className="input-group mb-3">
          <span className="input-group-text">CampaignName:</span>
          <input
            className="form-control"
            type="text"
            onChange={(o) => {
              setUserMessage({ ...userMessage, CampaignName: o.target.value });
            }}
            onKeyDown={(o) => {
              if (o.target.value.length >= 300) {
                o.preventDefault();
              }
            }}
          />
        </div>
        <div className="input-group mb-3">
          <span className="input-group-text">Number of Products:</span>
          <input
            className="form-control"
            type="number"
            min="1"
            onChange={(o) => {
              setUserMessage({ ...userMessage, Quantity: o.target.value });
            }}
          />
        </div>

        <button className="btn btn-secondary" onClick={handleAddMessage}>
          Send
        </button>
      </div>
    </>
  );
};
