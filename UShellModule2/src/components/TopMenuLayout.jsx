import React from "react";
import ReactDOM from "react-dom";
import {
  Routes,
  Route,
  useLocation,
  useNavigate,
  BrowserRouter,
} from "react-router-dom";
import { Breadcrumb, Layout, Menu } from "antd";

import "./TopMenuLayout.css";
import ProductList from "./Products/ProductList";
import TransactionList from "./Transactions/TransactionList";
import ProductDetails from "./Products/ProductDetails";
const { Header, Content, Footer } = Layout;

const TopMenuLayout = () => {
  const navigate = useNavigate();

  const goToTransactions = () => {
    navigate("/transactions");
  };

  const goToProducts = () => {
    navigate("/products");
  };

  const goToKey = (key) => {
    console.log("key", key);

    if (key.key == 1) {
      goToTransactions();
    }
    if (key.key == 2) {
      goToProducts();
    }
  };

  return (
    <Layout className="layout">
      <Header className="header">
        <div className="logo" />
        <Menu
          theme="dark"
          mode="horizontal"
          defaultSelectedKeys={["1"]}
          items={[
            {
              key: 1,
              label: "Transactions",
            },
            {
              key: 2,
              label: "Products",
            },
          ]}
          onClick={goToKey}
        />
      </Header>
      <Content
        style={{
          padding: "0 50px",
        }}
      >
        <div className="site-layout-content">
          <Routes>
            <Route
              path="/transactions"
              element={<TransactionList />}
              // element={<SideBar contentElement={<MyDay />}></SideBar>}
            />
            <Route
              path="/products"
              element={<ProductList />}
              // element={<SideBar contentElement={<MyDay />}></SideBar>}
            />
            <Route
              path="/products/:productKey"
              element={<ProductDetails />}
              // element={<SideBar contentElement={<MyDay />}></SideBar>}
            />
          </Routes>
        </div>
      </Content>
    </Layout>
  );
};

export default TopMenuLayout;
