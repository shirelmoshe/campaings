import { Link } from "react-router-dom";

export const CardProducts = ({ btnLink, productObject }) => {
  let { CompanyName, Product, Email, Price, CampaignName, productsId } =
    productObject;

  return (
    <>
      <div className="card product-container">
        <div className="card-body">
          <h2 className="card-title">{Product}</h2>
          <h5>Campaign Name: {CampaignName}</h5>
          <h5>Unit Price: {Price}</h5>
          <h5>Company Name: {CompanyName}</h5>
          <h5>Email: {Email}</h5>

          <Link
            onClick={() => btnLink(productObject)}
            to={`/Products/${productsId}`}
          >
            <button className="btn btn-primary">Buy</button>

            {productsId}
          </Link>
        </div>
      </div>
    </>
  );
};
