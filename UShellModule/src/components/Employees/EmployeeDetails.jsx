import React from "react";
import { useParams } from "react-router-dom";

const EmployeeDetails = ({inputData}) => {

  const params = useParams();
  const employeeKey = (inputData?.input ? inputData?.input : params.employeeKey);  

  const data = [
    {
      key: "1",
      name: "John Brown",
      age: 32,
      address: "New York No. 1 Lake Park",
      tags: ["nice", "developer"],
    },
    {
      key: "2",
      name: "Jim Green",
      age: 42,
      address: "London No. 1 Lake Park",
      tags: ["loser"],
    },
    {
      key: "3",
      name: "Joe Black",
      age: 32,
      address: "Sidney No. 1 Lake Park",
      tags: ["cool", "teacher"],
    },
  ];

  const employee = data.find((p) => p.key == employeeKey);
 
  return (
    <>
      <div>{employee?.name}</div>
      <div>{employee?.age}</div>
      <div>{employee?.address}</div>
    </>
  );
};

export default EmployeeDetails;
