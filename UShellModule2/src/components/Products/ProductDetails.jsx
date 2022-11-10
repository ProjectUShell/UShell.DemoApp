import React from "react";
import { useParams } from "react-router-dom";

const ProductDetails = ({inputData}) => {

  const params = useParams();
  const productKey = (inputData?.input ? inputData?.input : params.productKey);  

  const data = [
    {
      key: "1",
      name: "Apple",
      age: 32,
      origin: "Germany",
      tags: ["tasty", "round"],
    },
    {
      key: "2",
      name: "Strawberry",
      age: 42,
      origin: "Netherlands",
      tags: ["expensive"],
    },
    {
      key: "3",
      name: "Banana",
      age: 32,
      origin: "Columbia",
      tags: ["healthy", "weird"],
    },
  ];

  const product = data.find((p) => p.key == productKey);
 
  return (
    <>
      <div>{product?.name}</div>
      <div>{product?.age}</div>
      <div>{product?.address}</div>
    </>
  );
};

export default ProductDetails;
