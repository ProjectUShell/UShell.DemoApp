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
const { Header, Content, Footer } = Layout;

import "antd/dist/antd.css";
import "./index.css";
import "./App.css";

import TopMenuLayout from "./components/TopMenuLayout";

import { MyComponent } from "../node_modules/ushell-common-components/cjs";
import ShellLayout from "../node_modules/ushell-common-components/cjs/components/shell-layout/_Templates/ShellLayout";

const App = () => {
  // return <div>Hello</div>
  return <ShellLayout shellMenu={{ items: [] }}></ShellLayout>;
  return <MyComponent text="asd"></MyComponent>;

  return (
    <BrowserRouter>
      <TopMenuLayout></TopMenuLayout>
    </BrowserRouter>
  );
};
ReactDOM.render(<App />, document.getElementById("app"));
