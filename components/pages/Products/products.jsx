import React, { useState, useEffect, useContext } from "react";

import { getProducts } from "./../../servers/servers";
import { CardProducts } from "../../cardproducts/cardProducts";
import { UserContext } from "../../context/context";

export const Products = () => {
  const { setProduct } = useContext(UserContext);
  const [arrProducts, setArrProducts] = useState([]);

  let getProductsA = async () => {
    let ProductsArr = await getProducts();
    let arrPro = Object.values(ProductsArr);
    setArrProducts(arrPro);
  };

  useEffect(() => {
    getProductsA();
  }, []);

  const productDataUrl = (objectProduct) => {
    console.log("aa", objectProduct);
    setProduct(objectProduct);
  };

  return (
    <>
      {arrProducts.length > 0
        ? arrProducts.map((p) => {
            return (
              <>
                <CardProducts btnLink={productDataUrl} productObject={p} />
              </>
            );
          })
        : "loading"}
    </>
  );
};
