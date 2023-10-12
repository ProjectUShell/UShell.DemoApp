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
import Exercises from "./Exercises";
import Workout from "./Workout";
import "./TopMenuLayout.css";
import EmployeeList from "./Employees/EmployeeList";
import PaymentList from "./Payments/PaymentList";
import EmployeeDetails from "./Employees/EmployeeDetails";
import ValidationOverview from "./ValidationOverview";
const { Header, Content, Footer } = Layout;

const TopMenuLayout = () => {
  const navigate = useNavigate();

  const goToPayments = () => {
    navigate("/payments");
  };

  const goToEmployees = () => {
    navigate("/employees");
  };

  const goToValidation = () => {
    navigate("/validation");
  };

  const goToKey = (key) => {
    console.log("key", key);

    if (key.key == 2) {
      goToPayments();
    }
    if (key.key == 3) {
      goToEmployees();
    }
    if (key.key == 4) {
      goToValidation();
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
              key: 2,
              label: "Payments",
            },
            {
              key: 3,
              label: "Employees",
            },
            {
              key: 4,
              label: "Validation",
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
              path="/payments"
              element={<PaymentList />}
              // element={<SideBar contentElement={<MyDay />}></SideBar>}
            />
            <Route
              path="/employees"
              element={<EmployeeList />}
              // element={<SideBar contentElement={<MyDay />}></SideBar>}
            />
            <Route
              path="/employees/:employeeKey"
              element={<EmployeeDetails />}
              // element={<SideBar contentElement={<MyDay />}></SideBar>}
            />
            <Route
              path="/validation"
              element={<ValidationOverview />}
              // element={<SideBar contentElement={<MyDay />}></SideBar>}
            />
          </Routes>
        </div>
      </Content>
    </Layout>
  );
};

export default TopMenuLayout;
