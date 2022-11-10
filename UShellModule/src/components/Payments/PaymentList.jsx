import { Button, Space, Table, Tag } from "antd";
import React from "react";
import { useNavigate } from "react-router-dom";

const PaymentList = ({ inputData }) => {
  const navigate = useNavigate();

  const editEmployee = (employeeKey) => {
    if (inputData?.executeCommand) {
      inputData.executeCommand("ShowEmployeeDetails", employeeKey);
    } else {
      navigate(`../employees/${employeeKey}`);
    }
  };

  const columns = [
    {
      title: "Amount",
      dataIndex: "amount",
      key: "amount"
    },
    {
      title: "Date",
      dataIndex: "date",
      key: "date",
    },
    {
      title: "Employee",
      dataIndex: "employee",
      key: "employee",
      render: (text) => <a href="employees">{text}</a>,
    },
  ];
  const data = [
    {
      key: "1",
      amount: 20121,
      date: '13.02.2021',
      employee: "John Brow"
    },
    {
      key: "2",
      amount: 12311,
      date: '31.12.2022',
      employee: "Jim Green"
    },
    {
      key: "3",
      amount: 123,
      date: '02.12.2022',
      employee: "Joe Black"
    },
  ];

  return <Table columns={columns} dataSource={data} />;
};

export default PaymentList;
