import { Button, Space, Table, Tag } from "antd";
import React from "react";
import { useNavigate } from "react-router-dom";

const ProductList = ({ inputData }) => {
  const navigate = useNavigate();

  const editProduct = (productKey) => {
    if (inputData?.executeCommand) {
      inputData.executeCommand("ShowProductDetails", productKey);
    } else {
      navigate(`../products/${productKey}`);
    }
  };

  const columns = [
    {
      title: "Name",
      dataIndex: "name",
      key: "name",
      render: (text) => <a>{text}</a>,
    },
    {
      title: "Size",
      dataIndex: "size",
      key: "size",
    },
    {
      title: "Origin",
      dataIndex: "origin",
      key: "origin",
    },
    {
      title: "Tags",
      key: "tags",
      dataIndex: "tags",
      render: (_, { tags }) => (
        <>
          {tags.map((tag) => {
            let color = tag.length > 5 ? "geekblue" : "green";
            if (tag === "expensive") {
              color = "volcano";
            }
            return (
              <Tag color={color} key={tag}>
                {tag.toUpperCase()}
              </Tag>
            );
          })}
        </>
      ),
    },
    {
      title: "Action",
      key: "action",
      render: (_, record) => (
        <Space size="middle">
          <Button onClick={(e) => editProduct(record.key)}>Edit</Button>
        </Space>
      ),
    },
  ];
  const data = [
    {
      key: "1",
      name: "Apple",
      size: 32,
      origin: "Germany",
      tags: ["tasty", "round"],
    },
    {
      key: "2",
      name: "Strawberry",
      size: 42,
      origin: "Netherlands",
      tags: ["expensive"],
    },
    {
      key: "3",
      name: "Banana",
      size: 32,
      origin: "Columbia",
      tags: ["healthy", "weird"],
    },
  ];

  return <Table columns={columns} dataSource={data} />;
};

export default ProductList;
