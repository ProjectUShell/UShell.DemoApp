import { Button, Space, Table, Tag } from "antd";
import React from "react";
import { useNavigate } from "react-router-dom";

const TransactionList = ({ inputData }) => {
  const navigate = useNavigate();

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
      title: "Product",
      dataIndex: "product",
      key: "product",
      render: (text) => <a href="products">{text}</a>,
    },
  ];
  const data = [
    {
      key: "1",
      amount: 20121,
      date: '13.02.2021',
      product: "Apple"
    },
    {
      key: "2",
      amount: 12311,
      date: '31.12.2022',
      product: "Strawberry"
    },
    {
      key: "3",
      amount: 123,
      date: '02.12.2022',
      product: "Banana"
    },
  ];

  return <Table columns={columns} dataSource={data} />;
};

export default TransactionList;
