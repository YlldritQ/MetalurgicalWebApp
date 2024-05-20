import { Box } from "@mui/material";
import { DataGrid } from "@mui/x-data-grid";
import { GridColDef } from "@mui/x-data-grid/models";

const column: GridColDef[] = [{}];

const ProductGrid = ({ data }) => {
  return (
    <Box className="companies-gridd">
      <DataGrid row={data} columns={} />
    </Box>
  );
};

export default ProductGrid;
