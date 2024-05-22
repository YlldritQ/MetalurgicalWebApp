import React, { useEffect, useState } from "react";
import { useLocation, useNavigate } from "react-router-dom";
import { IOrders } from "../../types/global.typing";
import Swal from "sweetalert2";
import axios from "axios";
import { Add, Delete, Edit } from "@mui/icons-material";
import { Button } from "@mui/material";
import "./orders.scss";

const Orders = () => {
  const [orders, setOrders] = useState<IOrders[]>([]);
  const location = useLocation();
  const redirect = useNavigate();

  console.log(orders);

  const fetchProductsList = async () => {
    try {
      const response = await axios.get<IOrders[]>(
        "https://localhost:7149/api/Orders"
      );
      setOrders(response.data);
      if (location?.state) {
        Swal.fire({
          icon: "success",
          title: location?.state?.message,
        });
        redirect(location.pathname, { replace: true });
      }
    } catch (error) {
      alert("An Error Happend");
    }
  };

  useEffect(() => {
    fetchProductsList();
  }, []);

  console.log(orders);

  const redirectToEditPage = (id: string) => {
    redirect(`/orders/edit/${id}`);
  };

  const redirectToDeletePage = (id: string) => {
    redirect(`/orders/delete/${id}`);
  };
  return (
    <div className="orders">
      <h2>Orders List</h2>
      <Button variant="outlined" onClick={() => redirect("/orders/add")}>
        <Add />
      </Button>
      {orders.length === 0 ? (
        <h1>No Orders</h1>
      ) : (
        <div className="table-wrapper">
          <table>
            <thead>
              <tr>
                <th>ID</th>
                <th>Address</th>
                <th>Payment Method</th>
                <th>Total</th>
                <th>Order Date</th>
                <th>Product ID</th>
                <th>Operations</th>
              </tr>
            </thead>
            <tbody>
              {orders.map((order) => (
                <tr key={order.id}>
                  <td>{order.id}</td>
                  <td>{order.address}</td>
                  <td>{order.paymentMethod}</td>
                  <td>{order.total}</td>
                  <td>{order.orderDate}</td>
                  <td>{order.productId}</td>
                  <td>
                    <Button
                      variant="outlined"
                      color="warning"
                      sx={{ mx: 3 }}
                      onClick={() => redirectToEditPage(order.id)}
                    >
                      <Edit />
                    </Button>
                    <Button
                      variant="outlined"
                      color="error"
                      onClick={() => redirectToDeletePage(order.id)}
                    >
                      <Delete />
                    </Button>
                  </td>
                </tr>
              ))}
            </tbody>
          </table>
        </div>
      )}
    </div>
  );
};

export default Orders;
