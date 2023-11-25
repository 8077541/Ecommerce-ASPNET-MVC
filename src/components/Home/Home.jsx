import React from "react";
import HomePizza from "../Images/HomePizza.jpg";
import PizzaSlice from "../Images/PizzaSliceW.png";
import "./Home.css";

const Home = () => {
  return (
    <div id="Home">
      <div className="mainText">
        <img src={PizzaSlice} alt="logo" />
        <p className="textP">
          <h1 className="nameText">Virtual Pizza</h1>
          <h2 className="lesserText">Here for you whenever you feel hungry.</h2>
          <h3 className="name">Made by Dominik Janiak</h3>
        </p>
      </div>
    </div>
  );
};

export default Home;
