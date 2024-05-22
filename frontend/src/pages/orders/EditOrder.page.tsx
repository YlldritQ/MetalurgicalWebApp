import React, { useState } from "react";
import { ICreateOrders } from "../../types/global.typing";
import { useNavigate, useParams } from "react-router-dom";
import axios from "axios";
import {
  Button,
  FormControl,
  InputLabel,
  MenuItem,
  Select,
  TextField,
} from "@mui/material";

const EditOrder = () => {
  const [orders, setOrders] = useState<Partial<ICreateOrders>>({
    address: "",
    paymentMethod: "",
    total: "",
  });

  const redirect = useNavigate();
  const { id } = useParams();

  const changeHandler = (event: React.ChangeEvent<HTMLInputElement>) => {
    setOrders({
      ...orders,
      [event.target.name]: event.target.value,
    });
  };

  React.useEffect(() => {
    axios
      .get<ICreateOrders>(`https://localhost:7149/api/Orders/${id}`)
      .then(() =>
        setOrders({
          address: "",
          paymentMethod: "",
          total: "",
        })
      );
  }, []);

  const handleSaveBtnClick = () => {
    if (
      orders.address === "" ||
      orders.paymentMethod === "" ||
      orders.total === ""
    ) {
      alert("Enter Values");
      return;
    }
    const data: Partial<ICreateOrders> = {
      address: orders.address,
      paymentMethod: orders.paymentMethod,
      total: orders.total,
    };

    axios
      .put(`https://localhost:7149/api/Orders/${id}`, data)
      .then(() =>
        redirect("/orders", {
          state: { message: "Order Updated Successfully" },
        })
      )
      .catch(() => alert("Error"));
  };

  const handleBackBtnClick = () => {
    redirect("/orders");
  };

  return (
    <div className="edit-order">
      <h2>Edit Order</h2>
      <TextField
        autoComplete="off"
        label="Address"
        variant="outlined"
        name="address"
        value={orders.address}
        onChange={changeHandler}
      />
      <FormControl fullWidth>
        <InputLabel>Payment Method</InputLabel>
        <Select
          value={orders.paymentMethod}
          label="Payment Method"
          onChange={(e) =>
            setOrders({ ...orders, paymentMethod: e.target.value })
          }
        >
          <MenuItem value="Cash">Cash</MenuItem>
          <MenuItem value="CreditCard">CreditCard</MenuItem>
          <MenuItem value="Crypto">Crypto</MenuItem>
        </Select>
      </FormControl>

      <TextField
        autoComplete="off"
        label="Totali"
        variant="outlined"
        name="total"
        value={orders.total}
        onChange={changeHandler}
      />
      <div>
        <Button variant="outlined" color="primary" onClick={handleSaveBtnClick}>
          Save
        </Button>
        <Button
          variant="outlined"
          color="secondary"
          onClick={handleBackBtnClick}
        >
          Back
        </Button>
      </div>
    </div>
  );
};

export default EditOrder;
