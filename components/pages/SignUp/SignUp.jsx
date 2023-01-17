import { addUserServers } from "../../servers/servers";
import "./SignUp.css";
import { GetRoles } from "../../servers/servers";
import React, { useState, useEffect } from "react";
import { useAuth0 } from "@auth0/auth0-react";
export const SingUp = () => {
  const { user } = useAuth0();

  let user_id = user.sub;
  const handleRoles = async () => {
    let roles = await GetRoles(user_id);
  };
  useEffect(() => {
    handleRoles();
  }, []);

  const [userMessage, setUserMessage] = useState({
    userName: "",
    cellphoneNumber: "",
    email: "",
    UserType: "",
    user_id,
  });

  const handleAddUser = async () => {
    let json = userMessage;
    await addUserServers(json);
    setUserMessage({});
    document.querySelectorAll("input").forEach((input) => (input.value = ""));
  };
  const handleSelectChange = (event) => {
    setUserMessage({ ...userMessage, UserType: event.target.value });
  };

  return (
    <div className="student-inputs ">
      <div className="input-group mb-3">
        <span className="input-group-text">User name</span>
        <input
          className="form-control"
          type="text"
          onChange={(o) => {
            setUserMessage({ ...userMessage, userName: o.target.value });
          }}
        />
      </div>
      <div className="input-group mb-3">
        <span className="input-group-text">CellphoneNumber</span>
        <input
          className="form-control"
          type="text"
          onChange={(o) => {
            setUserMessage({ ...userMessage, cellphoneNumber: o.target.value });
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
        <span className="input-group-text">Twitterusername</span>
        <input
          className="form-control"
          type="text"
          onChange={(o) => {
            setUserMessage({ ...userMessage, twitterUsername: o.target.value });
          }}
        />
      </div>
      <div>
        <select onChange={handleSelectChange}>
          <option value="Association representative">
            Association representative
          </option>
          <option value="business company">business company</option>
          <option value="social activist">social activist</option>
        </select>

        <button className="btn btn-secondary" onClick={handleAddUser}>
          SAND
        </button>
      </div>
    </div>
  );
};
