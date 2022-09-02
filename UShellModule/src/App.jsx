import React from "react";
import ReactDOM from "react-dom";

import "./index.css";

import DemoComponent from "./components/DemoComponent";

const App = () => (
  <div className="container">    
    <demo-component name="Was anderes"></demo-component>
  </div>
);
ReactDOM.render(<App />, document.getElementById("app"));
