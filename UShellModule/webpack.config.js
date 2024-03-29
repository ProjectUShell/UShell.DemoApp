const HtmlWebPackPlugin = require("html-webpack-plugin");
const ModuleFederationPlugin = require("webpack/lib/container/ModuleFederationPlugin");

const deps = require("./package.json").dependencies;
module.exports = {
  output: {
    // publicPath: "http://localhost:3001/",
    publicPath: "https://ushell.org/ushell-demomodule/"
  },

  resolve: {
    extensions: [".tsx", ".ts", ".jsx", ".js", ".json"],
  },

  devServer: {
    port: 3001,
    historyApiFallback: true,
  },

  module: {
    rules: [
      {
        test: /\.m?js/,
        type: "javascript/auto",
        resolve: {
          fullySpecified: false,
        },
      },
      {
        test: /\.(css|s[ac]ss)$/i,
        use: ["style-loader", "css-loader", "postcss-loader"],
      },
      {
        test: /\.(ts|tsx|js|jsx)$/,
        exclude: /node_modules/,
        use: {
          loader: "babel-loader",
        },
      },
    ],
  },

  plugins: [
    new ModuleFederationPlugin({
      name: "ushell_demo_app",
      filename: "remoteEntry.js",
      remotes: {},
      exposes: {
        "./DemoComponent": "./src/components/DemoComponent.jsx",
        "./DemoComponent1": "./src/components/DemoComponent1.jsx",
        "./Exercises": "./src/components/Exercises.jsx",
        "./Workout": "./src/components/Workout.jsx",
        "./EmployeeList": "./src/components/Employees/EmployeeList.jsx",
        "./Test": "./src/components/Employees/Test.jsx",
        "./EmployeeDetails": "./src/components/Employees/EmployeeDetails.jsx",
        "./PaymentList": "./src/components/Payments/PaymentList.jsx",
        "./ValidationOverview": "./src/components/ValidationOverview.jsx",
        "./DropdownDemo": "./src/components/DropdownDemo.jsx"
      },
      shared: {
        ...deps,
        react: {
          singleton: true,
          requiredVersion: deps.react,
        },
        "react-dom": {
          singleton: true,
          requiredVersion: deps["react-dom"],
        },
      },
    }),
    new HtmlWebPackPlugin({
      template: "./src/index.html",
    }),
  ],
};
