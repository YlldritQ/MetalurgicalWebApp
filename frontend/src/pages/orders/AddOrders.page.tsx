import { useState } from "react";
import { ICreateOrders } from "../../types/global.typing";
import { useNavigate } from "react-router-dom";
import {
  Button,
  FormControl,
  InputLabel,
  MenuItem,
  Select,
  TextField,
} from "@mui/material";
import httpModule from "../../helpers/http.module";

const AddOrders = () => {
  const [orders, setOrders] = useState<ICreateOrders>({
    total: "",
    paymentMethod: "",
    address: "",
    productId: "",
    brand: "",
  });
  const redirect = useNavigate();

  const handleClickSaveBtn = () => {
    if (
      orders.productId === "" ||
      orders.paymentMethod === "" ||
      orders.address === "" ||
      orders.total === ""
    ) {
      alert("Fill all fields");
      return;
    }
    httpModule
      .post("https://localhost:7149/api/Orders/Create", orders)
      .then(() => redirect("/orders"))
      .catch((error) => console.log(error));
  };

  const handleClickBackBtn = () => {
    redirect("/orders");
  };
  return (
    <div>
      <div className="add-product">
        <h2>Add New Product</h2>

        <TextField
          autoComplete="off"
          label="Adress"
          variant="outlined"
          value={orders.address}
          onChange={(e) => setOrders({ ...orders, address: e.target.value })}
        />
        <TextField
          autoComplete="off"
          label="Total"
          variant="outlined"
          value={orders.total}
          onChange={(e) => setOrders({ ...orders, total: e.target.value })}
        />
        <TextField
          autoComplete="off"
          label="Brand"
          variant="outlined"
          value={orders.brand}
          onChange={(e) => setOrders({ ...orders, brand: e.target.value })}
        />
        <TextField
          autoComplete="off"
          label="ProductId"
          variant="outlined"
          value={orders.productId}
          onChange={(e) => setOrders({ ...orders, productId: e.target.value })}
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
        <div className="btns">
          <Button
            variant="outlined"
            color="primary"
            onClick={handleClickSaveBtn}
          >
            Save
          </Button>
          <Button
            variant="outlined"
            color="secondary"
            onClick={handleClickBackBtn}
          >
            Back
          </Button>
        </div>
      </div>
    </div>
  );
};

export default AddOrders;
