import React, { useState, useEffect } from "react";
import axios from "axios";
import "./AdminPanel.css";
const AdminPanel = () => {
  const [loading, setLoading] = useState(true);
  const [orders, SetOrders] = useState([]);

  useEffect(() => {
    const load = async () => {
      setLoading(true);

      const response = await axios.get(
        `http://localhost:5037/api/Order/GetAll`
      );
      SetOrders(response.data.data);
      console.log(orders);
      setLoading(false);
    };
    load();
  }, []);

  if (loading) {
    return (
      <div id="loading">
        <div className="lds-ellipsis">
          <div></div>
          <div></div>
          <div></div>
          <div></div>
        </div>
      </div>
    );
  }
  return (
    <div id="admin-panel">
      <div>
        <ol>
          {orders ? (
            orders.map((item) => {
              <li key={item.id}>
                <h1>{item.date} insallah</h1>;
              </li>;
            })
          ) : (
            <h1>Error</h1>
          )}
        </ol>
        <div>{orders[0].date}</div>
      </div>
    </div>
  );
};

export default AdminPanel;
