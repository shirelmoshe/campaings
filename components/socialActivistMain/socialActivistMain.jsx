import { Home } from "../pages/Home/Home";
import React from "react";
import { Routes, Route } from "react-router-dom";
import { Campaigns } from "./../pages/campaigns/campaigns";
import { Products } from "./../pages/Products/products";
import { ProductInfo } from "./../pages/oneProduct/oneProduct";
import { SingUp } from "./../pages/SignUp/SignUp";
import { CampaignSupport } from "../pages/CampaignSupport/CampaignSupport";
import { SocialActivistUser } from "../pages/socialActivist/socialActivist";
import NavbarSocialActivist from "../Navbar/Navbar";
import { useEffect } from "react";
import { useState } from "react";
import { GetRoles } from "../servers/servers";
import { useAuth0 } from "@auth0/auth0-react";
import { MoneyTrackingTable } from "../pages/MoneyTrackingTable/MoneyTrackingTable";
export const SocialActivists = () => {
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
      <NavbarSocialActivist />
      <Routes>
        <Route
          path="/SocialActivists"
          element={<SocialActivistUser user={user_id} />}
        ></Route>
        <Route path="/" element={<Home />}></Route>
        <Route path="/Campaigns" element={<Campaigns />}></Route>
        <Route path="/SingUp" element={<SingUp />}></Route>
        <Route path="/Products" element={<Products />}></Route>
        <Route path="/productsId/:productsId" element={<ProductInfo />}></Route>
        <Route path="/CampaignSupport" element={<CampaignSupport />}></Route>
        <Route path="/MoneyTracking" element={<MoneyTrackingTable />}></Route>
      </Routes>
    </>
  );
};
