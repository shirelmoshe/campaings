import axios from "axios";

export const addDonation = async (userComment) => {
  console.log(userComment);

  await axios.post("http://localhost:7200/api/Function1/donation", userComment);
};
export const addSale = async (userComment) => {
  console.log(userComment);

  await axios.post("http://localhost:7200/api/Function1/addSale", userComment);
};

export const addCanpaignServers = async (userComment) => {
  console.log(userComment);

  await axios.post(
    "http://localhost:7200/api/Function1/creatingCampaign",
    userComment
  );
};
export const addSupportServers = async (userComment) => {
  console.log(userComment);

  await axios.post("http://localhost:7200/api/Function1/Support", userComment);
};
export const addUserServers = async (userComment) => {
  console.log(userComment);

  await axios.post("http://localhost:7200/api/Function1/SingUp", userComment);
};

export const getCampaigns = async () => {
  try {
    let results = await fetch("http://localhost:7200/api/Function1/Campaigns");
    if (!results.ok) {
      throw new Error(`HTTP error! status: ${results.status}`);
    }
    let response = await results.json();
    return response;
  } catch (error) {
    console.error("DONT");
  }
};

export const getProducts = async () => {
  try {
    let results = await fetch("http://localhost:7200/api/Function1/Products");
    if (!results.ok) {
      throw new Error(`HTTP error! status: ${results.status}`);
    }
    let response = await results.json();
    return response;
  } catch (error) {
    console.error("DONT");
  }
};

export const getShippingDataById = async (productId) => {
  try {
    let endpoint = `http://localhost:7200/api/Function1/Shipping/${productId}`;
    let product = await axios.get(endpoint);
    console.log(product);
    return product.data;
  } catch (error) {
    console.error(error);
  }
};

export const getsocialActivistDataById = async (user_id) => {
  try {
    let endpoint = `http://localhost:7200/api/Users/SocialActivists/${user_id}`;
    console.log(user_id);
    let user = await axios.get(endpoint);
    console.log(user_id);
    return user.data;
  } catch (error) {
    console.error(error);
  }
};
export const getCompanyOwnerUserDataById = async (user_id) => {
  try {
    let endpoint = `http://localhost:7200/api/Users/CompanyOwnerUser/${user_id}`;
    console.log(user_id);
    let user = await axios.get(endpoint);
    console.log(user_id);
    return user.data;
  } catch (error) {
    console.error(error);
  }
};

export const getAdminDataById = async (user_id) => {
  try {
    let endpoint = `http://localhost:7200/api/Users/Admin/${user_id}`;
    console.log(user_id);
    let user = await axios.get(endpoint);
    console.log(user_id);
    return user.data;
  } catch (error) {
    console.error(error);
  }
};

export const getAssociationRepresentativeDataById = async (user_id) => {
  try {
    let endpoint = `http://localhost:7200/api/Users/AssociationRepresentative/${user_id}`;
    let user = await axios.get(endpoint);
    console.log(user);
    return user.data;
  } catch (error) {
    console.error(error);
  }
};

export const getProductDataById = async (productsId) => {
  try {
    let endpoint = `http://localhost:7200/api/Function1/Products/${productsId}`;
    let product = await axios.get(endpoint);
    console.log(product);
    return product.data;
  } catch (error) {
    console.error(error);
  }
};

export const GetRoles = async (userId) => {
  let result = await axios.get(`http://localhost:7200/api/roles/${userId}`);
  if (result.status === 200) {
    return result.data;
  } else {
    return {};
  }
};

export const getSalesData = async () => {
  try {
    let endpoint = "http://localhost:7200/api/Function1/Sales";
    let Sales = await axios.get(endpoint);
    console.log(Sales);
    return Sales.data;
  } catch (error) {
    console.error(error);
  }
};

export const getShipping = async () => {
  try {
    let endpoint = "http://localhost:7200/api/Function1/Shipping";
    let Sales = await axios.get(endpoint);
    console.log(Sales);
    return Sales.data;
  } catch (error) {
    console.error(error);
  }
};

export const getCampaingsTable = async () => {
  try {
    let endpoint = "http://localhost:7200/api/Function1/CampaingsTable";
    let Sales = await axios.get(endpoint);
    console.log(Sales);
    return Sales.data;
  } catch (error) {
    console.error(error);
  }
};
export const getMoneyTrackingTable = async () => {
  try {
    let endpoint = "http://localhost:7200/api/Users/MoneyTracking";
    let Sales = await axios.get(endpoint);
    console.log(Sales);
    return Sales.data;
  } catch (error) {
    console.error(error);
  }
};

export const getTwitterTable = async () => {
  try {
    let endpoint = "http://localhost:7200/api/Function1/TwitterTable";
    let Sales = await axios.get(endpoint);
    console.log(Sales);
    return Sales.data;
  } catch (error) {
    console.error(error);
  }
};

export const getUsersData = async () => {
  try {
    let endpoint = "http://localhost:7200/api/Function1/User";
    let Sales = await axios.get(endpoint);
    console.log(Sales);
    return Sales.data;
  } catch (error) {
    console.error(error);
  }
};
