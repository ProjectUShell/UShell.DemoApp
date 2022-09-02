// import React from 'react';
// import logo from './logo.svg';
// import './App.css';
// import Graphs from './Graphs'

// function App() {
//   return (
//     <div className="App">
//         <Graphs username="wesbos"></Graphs>
//     </div>
//   );
// }

// export default App;

import * as React from "react";
import { render, unmountComponentAtNode } from "react-dom";
// import Graphs from './Graphs'

class DemoComponent extends HTMLElement {
  // username = '';
  constructor() {
    super();

    // console.log("app", app);
    // this.name = app.name;
    // this.observer = new MutationObserver(() => this.update());
    // this.observer.observe(this, { attributes: true });
  }

  connectedCallback() {
    this._innerHTML = this.innerHTML;
    this.name = this.getAttribute("name");
    console.log("this.name", this.name);
    if (this.name === undefined || this.name === null) {
      throw "NONONO";
    }
    this.mount();
  }

  disconnectedCallback() {
    this.unmount();
    // this.observer.disconnect();
  }

  update() {
    this.unmount();
    this.mount();
  }

  mount() {
    // const propTypes = Graphs.propTypes ? Graphs.propTypes : {};
    // const props = {
    //   ...this.getProps(this.attributes, propTypes),
    // };
    render(<div>Demo Component still working {this.name}</div>, this);
  }

  unmount() {
    // unmountComponentAtNode(this);
  }

  getProps(attributes, propTypes) {
    // propTypes = propTypes|| {};
    // let arr  =  [ ...attributes ]
    //   .filter(attr => attr.name !== 'style')
    //   .map(attr => this.convert(propTypes, attr.name, attr.value))
    //   .reduce((props, prop) =>
    //     ({ ...props, [prop.name]: prop.value }), {});
    // return arr
  }

  convert(propTypes, attrName, attrValue) {
    // const propName = Object.keys(propTypes)
    //   .find(key => key.toLowerCase() == attrName);
    // let value = attrValue;
    // if (attrValue === 'true' || attrValue === 'false')
    //   value = attrValue == 'true';
    // else if (!isNaN(attrValue) && attrValue !== '')
    //   value = +attrValue;
    // else if (/^{.*}/.exec(attrValue))
    //   value = JSON.parse(attrValue);
    // return {
    //   name: propName ? propName : attrName,
    //   value: value
    // };
  }
}

customElements.define("demo-component", DemoComponent);
export default DemoComponent;
