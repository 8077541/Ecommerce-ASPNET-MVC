import React from "react";
import ReactDOM from "react-dom/client";
import "./index.css";
import App from "./App";
import reportWebVitals from "./reportWebVitals";
import { BrowserRouter } from "react-router-dom";
import { Route } from "react-router-dom";
import { Routes } from "react-router-dom";
import Navbar from "./components/Navbar/Navbar.jsx";
import Home from "./components/Home/Home.jsx";
import About from "./components/About/About.jsx";
import Contact from "./components/Contact/Contact.jsx";
import NewOrder from "./components/NewOrder/NewOrder.jsx";

const root = ReactDOM.createRoot(document.getElementById("root"));
root.render(
  <React.StrictMode>
    <BrowserRouter>
      <Routes>
        <Route
          path="/"
          element={
            <div>
              <Navbar /> <Home />
            </div>
          }
        />
        <Route
          path="/about"
          element={
            <div>
              <Navbar></Navbar>
              <About></About>
            </div>
          }
        />
        <Route
          path="/contact"
          element={
            <div>
              <Navbar></Navbar>
              <Contact></Contact>
            </div>
          }
        ></Route>
        <Route
          path="/newOrder"
          element={
            <div>
              <Navbar></Navbar>
              <NewOrder></NewOrder>
            </div>
          }
        ></Route>
      </Routes>
    </BrowserRouter>
  </React.StrictMode>
);

// If you want to start measuring performance in your app, pass a function
// to log results (for example: reportWebVitals(console.log))
// or send to an analytics endpoint. Learn more: https://bit.ly/CRA-vitals
reportWebVitals();
