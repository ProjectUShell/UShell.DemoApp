import React from "react";
import "./App.css";

// import MyComponent from "ushell-common-components/dist/esm/MyComponent";

// import Table from "ushell-common-components/dist/esm/components/guifad/_Organisms/Table";
// import { Guifad } from "ushell-common-components";
import { Table } from "ushell-common-components";

import ShellLayout from "ushell-common-components/dist/esm/components/shell-layout/_Templates/ShellLayout";

function App() {
  // return (
  //   <ShellLayout shellMenu={{ items: [] }} title="test">
  //     {/* <MyComponent text="test"></MyComponent> */}
  //   </ShellLayout>
  // );
  return (
    <Table columns={[{ label: "id", fieldName: "id" }]} records={[]}></Table>
  );
  // return <MyComponent text="asd"></MyComponent>;
  // return <GuifadFuse fuseUrl="https://localhost:7204/"></GuifadFuse>;
}

export default App;
