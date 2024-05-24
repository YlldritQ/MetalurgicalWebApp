import {
  Box,
  Select,
  MenuItem,
  SelectChangeEvent,
  TextField,
  Stack,
  Button,
} from "@mui/material";
import axios from "axios";
import { ChangeEvent, useEffect, useState } from "react";
import { IProduct } from "../../types/global.typing";
import { useNavigate } from "react-router-dom";

const URL = "https://localhost:7149/api/Product/Get";
const ADD_ORDER_URL = "https://localhost:7149/api/Orders/Create";

type Product = {
  id: number;
  title: string;
  brand: string;
  size: string;
};

type FormValues = {
  total: number;
  address: string;
  paymentMethod: string;
  productId: number;
  brand: string;
};

export const AddOrder = () => {
  const [isAdding, setIsAdding] = useState(false);
  const [formValues, setFormValues] = useState<FormValues>({
    total: 0,
    address: "",
    paymentMethod: "",
    productId: 0,
    brand: "",
  });
  const [productsList, setProductsList] = useState<Product[] | null>(null);

  const redirect = useNavigate();

  const getProductsList = async () => {
    try {
      const res = await axios.get(URL);
      setProductsList(res.data);
    } catch (error) {
      console.error("Error fetching products:", error);
    }
  };

  const getProductById = async () => {
    await axios
      .get<IProduct>(
        `https://localhost:7149/api/Product/${formValues?.productId}`
      )
      .then((res) => {
        const { data } = res;

        setFormValues((prevValues) => ({
          ...prevValues,
          brand: data.brand,
        }));
      });
  };

  const addNewOrder = async () => {
    try {
      setIsAdding(true);
      await axios.post(ADD_ORDER_URL, formValues).then(() => {
        setIsAdding(false);
        redirect("/orders");
      });
    } catch (error) {
      console.log("Error :", error);
    }
  };

  useEffect(() => {
    getProductsList();
  }, []);

  useEffect(() => {
    if (formValues?.productId) {
      getProductById();
    }
  }, [formValues?.productId]);

  const handleInputChange = (
    event:
      | ChangeEvent<HTMLInputElement | HTMLTextAreaElement>
      | SelectChangeEvent<unknown>
  ) => {
    const { name, value } = event.target;
    setFormValues((prevValues) => ({
      ...prevValues,
      [name]: value,
    }));
  };

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
        <TextField
          name="total"
          type="number"
          onChange={handleInputChange}
          placeholder="Total"
        />
        <Select
          name="productId"
          value={formValues.productId}
          onChange={handleInputChange}
          placeholder="Product"
        >
          {productsList?.map((p) => (
            <MenuItem key={p.id} value={p.id}>
              {p.title}
            </MenuItem>
          ))}
        </Select>
        <TextField
          name="address"
          onChange={handleInputChange}
          placeholder="Address"
        />
        <TextField
          name="paymentMethod"
          onChange={handleInputChange}
          placeholder="Payment Method"
        />
        <TextField
          name="brand"
          onChange={handleInputChange}
          placeholder="Brand"
          value={formValues?.brand}
        />
        <Button
          variant={isAdding ? "outlined" : "contained"}
          disabled={isAdding}
          onClick={addNewOrder}
        >
          {isAdding ? "Adding new order..." : "Add new order"}
        </Button>
      </Stack>
    </Box>
  );
};
