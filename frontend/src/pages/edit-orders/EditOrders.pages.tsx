import axios from "axios";
import { useEffect, useState } from "react";
import { useParams } from "react-router-dom";
import { Order } from "../orders/Orders.pages";

const ORDER = (id: string | undefined) =>
  `https://localhost:7149/api/Orders/${id}`;

export const EditOrders = () => {
  const [orderDetails, setOrderDetails] = useState<Order>();

  const { id } = useParams();

  const getOrder = async () => {
    try {
      await axios.get(ORDER(id)).then((res) => {
        setOrderDetails(res.data);
      });
    } catch (error) {}
  };

  useEffect(() => {
    if (id) {
      getOrder();
    }
  }, [id]);

  return <div>{orderDetails?.brand}</div>;
};
