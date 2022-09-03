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
import "./TopMenuLayout.css"
const { Header, Content, Footer } = Layout;

const TopMenuLayout = () => {
  const navigate = useNavigate();

  const goToExercices = () => {
    navigate("/exercises");
  };

  const goToWorkout = () => {
    navigate("/workout");
  };

  const goToKey = (key) => {
    
    if (key.key == 1) {
      console.log(key);
      goToExercices();
    }
    if (key.key == 2) {
      console.log(key);
      goToWorkout();
    }
  };

  return (
    <Layout className="layout">
      <Header className="header">
        <div className="logo" />
        <Menu
          theme="dark"
          mode="horizontal"
          defaultSelectedKeys={["2"]}
          items={[
            {
              key: 1,
              label: "Exercises",
            },
            {
              key: 2,
              label: "Workout",
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
          </Routes>
        </div>
      </Content>     
    </Layout>
  );
};

export default TopMenuLayout;
