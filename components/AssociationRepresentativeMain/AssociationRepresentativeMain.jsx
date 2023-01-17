import { useEffect } from "react";
import { useState } from "react";
import { GetRoles } from "../servers/servers";
import { useAuth0 } from "@auth0/auth0-react";
import { Routes, Route } from "react-router-dom";
import { CreatingCampaign } from "./../pages/CreatingCampaign/CreatingCampaign";
import { Campaigns } from "./../pages/campaigns/campaigns";
import { Products } from "./../pages/Products/products";
import { ProductInfo } from "./../pages/oneProduct/oneProduct";
import { SingUp } from "./../pages/SignUp/SignUp";
import { Home } from "../pages/Home/Home";
import { AssociationRepresentativeUser } from "../pages/AssociationRepresentative/AssociationRepresentative";
import { NavbarAssociationRepresentative } from "../AssociationRepresentativeNavbar/AssociationRepresentativeNavbar";

export const AssociationRepresentative = () => {
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
      <NavbarAssociationRepresentative />
      <Routes>
        <Route path="/" element={<Home />}></Route>
        <Route path="/creatingCampaign" element={<CreatingCampaign />}></Route>
        <Route path="/Campaigns" element={<Campaigns />}></Route>
        <Route path="/SingUp" element={<SingUp />}></Route>
        <Route path="/Products" element={<Products />}></Route>
        <Route path="/productsId/:productsId" element={<ProductInfo />}></Route>
        <Route
          path="/AssociationRepresentative"
          element={<AssociationRepresentativeUser user={user_id} />}
        ></Route>
      </Routes>
    </>
  );
};
