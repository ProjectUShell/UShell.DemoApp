import React, { useState } from "react";
import { IDataSource } from "ushell-modulebase";

const Guifad: React.FC<{ fuseUrl: string }> = ({ fuseUrl }) => {
  const [test, setTest] = useState(0);

  // const [dataSource, setDataSource] = useState<any>({})
  console.log("guifad");
  // GetFuseDatasource(fuseUrl).then((ds) => {
  //   setDataSource(ds)
  //   dataSource?.getRecords().then((r) => {
  //     console.log('records', r)
  //     console.log('es', dataSource.entitySchema)
  //   })
  // })
  return <div>guifad123</div>;
};

export default Guifad;
