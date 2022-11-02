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
import EmployeeDetails from "./Employees/EmployeeDetails";
const { Header, Content, Footer } = Layout;

const TopMenuLayout = () => {
  const navigate = useNavigate();

  const goToExercices = () => {
    navigate("/exercises");
  };

  const goToWorkout = () => {
    navigate("/workout");
  };

  const goToEmployees = () => {
    navigate("/employees");
  };

  const goToKey = (key) => {
    console.log("key",key);
    if (key.key == 1) {
      goToExercices();
    }
    if (key.key == 2) {
      goToWorkout();
    }
    if (key.key == 3) {
      goToEmployees();
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
              label: "Exercises",
            },
            {
              key: 2,
              label: "Workout",
            },
            {
              key: 3,
              label: "Employees",
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
              path="/exercises"
              // element={<TopBar contentElement={<MyDay />}></TopBar>}
              element={<Exercises />}
            />
            <Route
              path="/workout"
              element={<Workout />}
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
          </Routes>
        </div>
      </Content>
    </Layout>
  );
};

export default TopMenuLayout;
