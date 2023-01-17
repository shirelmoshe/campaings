import React from "react";
import "./DimaniCard.css";

export const DimaniCard = ({
  userId,
  associationName,
  email,
  uri,
  hashtag,
  handleMoreProductInfo,
}) => {
  return (
    <div class="card" key={userId}>
      <div class="card-body">
        <h5 class="card-title">{hashtag}</h5>
        <p class="card-text">{associationName}</p>
        <p class="card-text">{uri}</p>
        <a href="/" class="btn btn-primary">
          Go somewhere
        </a>
      </div>
      <button onClick={handleMoreProductInfo}>More Product Info</button>
    </div>
  );
};
