import "./products.scss";
import httpModule from "../../helpers/http.module";
import { useEffect, useState } from "react";
import { IProduct } from "../../types/global.typing";
import { Button } from "@mui/material";
import { useNavigate } from "react-router-dom";
import { Add } from "@mui/icons-material";

const Products = () => {
  const [products, setProducts] = useState<IProduct[]>([]);
  const [loading, setLoading] = useState<boolean>(false);
  const redirect = useNavigate();

  useEffect(() => {
    setLoading(true);
    httpModule
      .get<IProduct[]>("/Product/Get")
      .then((response) => {
        setProducts(response.data);
        setLoading(false);
      })
      .catch((error) => {
        alert("Error");
        console.log(error);
        setLoading(false);
      });
  }, []);
  console.log(products);
  return (
    <div className="content products">
      <div className="heading">
        <h2>Companies</h2>
        <Button variant="outlined" onClick={() => redirect("/products/add")}>
          <Add />
        </Button>
      </div>
    </div>
  );
};

export default Products;
