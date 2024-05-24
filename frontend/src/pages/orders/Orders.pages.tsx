import { Add } from "@mui/icons-material";
import { Box, Button, Stack } from "@mui/material";
import axios from "axios";
import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";

const ORDERS_LIST = "https://localhost:7149/api/Orders";

type ProductOrders = {
  id: number;
  createdAt: string;
  updatedAt: string;
  isActive: boolean;
  isDeleted: boolean;
  productId: number;
  product: {
    id: number;
    createdAt: string;
    updatedAt: string;
    isActive: boolean;
    isDeleted: boolean;
    brand: string;
    title: string;
    product_Orders: string[];
  };
  orderId: number;
  order: string;
};

export type Order = {
  id: number;
  createdAt: string;
  updatedAt: string;
  isActive: boolean;
  isDeleted: boolean;
  orderDate: string;
  total: number;
  address: string;
  paymentMethod: string;
  brand: string;
  product_Orders: ProductOrders[];
};

const Orders = () => {
  const [orders, setOrders] = useState<Order[] | null>(null);

  const redirectToEditPage = (id: string) => {
    redirect(`/orders/edit/${id}`);
  };

  const getOrders = async () => {
    try {
      await axios.get(ORDERS_LIST).then((res) => {
        setOrders(res.data);
      });
    } catch (error) {}
  };

  const redirect = useNavigate();

  useEffect(() => {
    getOrders();
  }, []);

  return (
    <Box
      sx={{
        display: "flex",
        justifyContent: "center",
        alignItems: "center",
        width: "100%",
        height: "100vh",
      }}
    >
      <Stack direction="column" spacing={1}>
        <Button
          variant="outlined"
          startIcon={<Add />}
          onClick={() => redirect("/orders/add")}
        >
          Add new order
        </Button>
        {orders?.map((o) => {
          return (
            <Stack key={o.id} direction="row" alignItems="center">
              <p>{o.brand}</p>
              <Button size="small" onClick={() => redirectToEditPage(o.id)}>
                Edit
              </Button>
              <Button size="small">Delete</Button>
            </Stack>
          );
        })}
      </Stack>
    </Box>
  );
};

export default Orders;
