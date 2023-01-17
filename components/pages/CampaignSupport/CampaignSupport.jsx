import React, { useState } from "react";
import { addSupportServers } from "../../servers/servers";

export const CampaignSupport = (props) => {
  const [userMessage, setUserMessage] = useState({
    associationName: "",
    hashtag: "",
    email: "",
    userName: "",
    twitterUsername: " ",
    CampaignName: "",
  });
  const [charactersLeft, setCharactersLeft] = useState(300);

  const handleAddMessage = async () => {
    let json = userMessage;
    await addSupportServers(json);
    setUserMessage({});
    document.querySelectorAll("input").forEach((input) => (input.value = ""));
  };

  return (
    <div className="student-inputs ">
      <div className="input-group mb-3">
        <span className="input-group-text">association Name</span>
        <input
          className="form-control"
          type="text"
          onChange={(o) => {
            setUserMessage({ ...userMessage, associationName: o.target.value });
          }}
        />
      </div>
      <div className="input-group mb-3">
        <span className="input-group-text">hashtag</span>
        <input
          className="form-control"
          type="text"
          onChange={(o) => {
            setUserMessage({ ...userMessage, hashtag: o.target.value });
          }}
        />
      </div>
      <div className="input-group mb-3">
        <span className="input-group-text">Email</span>
        <input
          className="form-control"
          type="email"
          onChange={(o) => {
            setUserMessage({ ...userMessage, email: o.target.value });
          }}
        />
      </div>
      <div className="input-group mb-3">
        <span className="input-group-text">userName</span>
        <input
          className="form-control"
          type="text"
          onChange={(o) => {
            setUserMessage({ ...userMessage, userName: o.target.value });
            setCharactersLeft(300 - o.target.value.length);
          }}
          onKeyDown={(o) => {
            if (o.target.value.length >= 300) {
              o.preventDefault();
            }
          }}
          maxLength={300}
        />
        <div>Characters left: {charactersLeft}</div>
      </div>
      <div className="input-group mb-3">
        <span className="input-group-text"> twitterUsername</span>
        <input
          className="form-control"
          type="email"
          onChange={(o) => {
            setUserMessage({ ...userMessage, twitterUsername: o.target.value });
          }}
        />
      </div>
      <div className="input-group mb-3">
        <span className="input-group-text">CampaignName</span>
        <input
          className="form-control"
          type="text"
          onChange={(o) => {
            setUserMessage({ ...userMessage, CampaignName: o.target.value });
            setCharactersLeft(300 - o.target.value.length);
          }}
          onKeyDown={(o) => {
            if (o.target.value.length >= 300) {
              o.preventDefault();
            }
          }}
          maxLength={300}
        />
        <div>Characters left: {charactersLeft}</div>
      </div>
      <button className="btn btn-secondary" onClick={handleAddMessage}>
        Send
      </button>
    </div>
  );
};
