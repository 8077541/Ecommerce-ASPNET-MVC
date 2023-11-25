import React from "react";
import { Link } from "react-router-dom";

const Contact = () => {
  return (
    <div>
      <p className="aboutSection">
        <h2 className="aboutText">
          Email: dominikjaniakxyz@gmail.com <br></br>Phone Number: +48 511 840
          868
          <br></br>Github:{" "}
          <Link to="https://github.com/8077541/Ecommerce-ASPNET-MVC-EF">
            https://github.com/8077541/Ecommerce-ASPNET-MVC-EF
          </Link>
          <br></br>
          Linkedin:{" "}
          <Link to="https://www.linkedin.com/in/dominik-janiak-b71915295/">
            https://www.linkedin.com/in/dominik-janiak-b71915295/
          </Link>
        </h2>
      </p>
    </div>
  );
};

export default Contact;
