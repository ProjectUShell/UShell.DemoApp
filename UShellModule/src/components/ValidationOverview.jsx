import React from "react";

const ValidationOverview = ({ inputData }) => {
  const appScope = inputData.widgetHost.getApplicationScope();
  return (
    <div>
      ValidationOverview
      <div> Backend-Url: {inputData.state.unitOfWork.backendApiUrl}</div>
      <div>
        {" "}
        Profile: {inputData.widgetHost.getApplicationScope().profileId}
      </div>
    </div>
  );
};

export default ValidationOverview;
