import { Home } from "../pages/Home/Home";
import { Routes, Route } from "react-router-dom";
import { UsersTable } from "../pages/Users/user";
import { TwitterTable } from "../pages/TwitterTable/TwitterTable";
import { AdminUser } from "../AdminUser/Admin";
import { CampaingsTable } from "../pages/CampaingsTable/CampaingsTable";
import { SalesTable } from "../pages/Sales/sales";
import { Campaigns } from "./../pages/campaigns/campaigns";
import { SingUp } from "./../pages/SignUp/SignUp";
import { Products } from "./../pages/Products/products";
import { ProductInfo } from "./../pages/oneProduct/oneProduct";
import React from "react";
import NavbarAdmin from "../NavabarAdmin/NavabarAdmin";
import { useEffect } from "react";
import { useState } from "react";
import { GetRoles } from "../servers/servers";
import { useAuth0 } from "@auth0/auth0-react";

export const Admin = () => {
  const { user } = useAuth0();
  const [role, setRole] = useState([]);

  let user_id = user.sub;
  const handleRoles = async () => {
    let roles = await GetRoles(user_id);

    setRole(roles);
  };
  useEffect(() => {
    handleRoles();
  }, []);
  return (
    <>
      <NavbarAdmin />
      <Routes>
        <Route path="/" element={<Home />}></Route>
        <Route path="/Campaigns" element={<Campaigns />}></Route>
        <Route path="/SingUp" element={<SingUp />}></Route>
        <Route path="/Products" element={<Products />}></Route>
        <Route path="/Sales" element={<SalesTable />}></Route>
        <Route path="/Products/:productsId" element={<ProductInfo />}></Route>
        <Route path="/User" element={<UsersTable />}></Route>
        <Route path="/TwitterTable" element={<TwitterTable />}></Route>
        <Route path="/CampaingsTable" element={<CampaingsTable />}></Route>
        <Route path="/CampaingsTable" element={<SalesTable />}></Route>
        <Route path="/Admin" element={<AdminUser user={user_id} />}></Route>
      </Routes>
    </>
  );
};
