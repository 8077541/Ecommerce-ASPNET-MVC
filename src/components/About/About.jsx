import React from "react";
import "./About.css";
import { Link } from "react-router-dom";
const About = () => {
  return (
    <div>
      <p className="aboutSection">
        <h1 className="appName">Virtual Pizza</h1>
        <h2 className="aboutText">
          is a simple application showcasing some of my abilites in .Net, React
          and SQL. Its purpose is to allow a user to create a desired order, and
          send it over to admin panel where it can be further edited, accepted
          or declined. All the data regarding pizzas or orders is being pulled
          from database and can be updated in real time. You can check out the
          code on my github at{" "}
          <Link to="https://github.com/8077541/Ecommerce-ASPNET-MVC-EF">
            https://github.com/8077541/Ecommerce-ASPNET-MVC-EF
          </Link>
        </h2>
      </p>
    </div>
  );
};

export default About;
