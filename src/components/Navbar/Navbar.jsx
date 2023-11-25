import React from "react";
import { Link } from "react-router-dom";
import "./Navbar.css";
import logo from "../Images/virtualPizzaLogo.png";
import HomePizza from "../Images/HomePizza.jpg";

const Navbar = () => {
  return (
    <div className="NavBar">
      <header>
        <img className="Logo" alt="Logo" src={logo}></img>
        <nav>
          <ul className="NavLinks">
            <li>
              <Link to="/" className="NavLink">
                Home
              </Link>
            </li>
            <li>
              <Link to="/about" className="NavLink">
                About
              </Link>
            </li>
            <li>
              <Link to="/contact" className="NavLink">
                Contact
              </Link>
            </li>
          </ul>
        </nav>
        <Link className="cta" to="/newOrder">
          <button className="buttonStyle">Order</button>
        </Link>
        <Link className="cta" to="/adm">
          <button className="buttonStyle">Admin Demo</button>
        </Link>
      </header>
      <div className="imgbox">
        <img src={HomePizza} className="center-fit" alt="background"></img>
      </div>
    </div>
  );
};

export default Navbar;
