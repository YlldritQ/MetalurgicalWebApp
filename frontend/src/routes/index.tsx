import { Routes, Route, Navigate } from "react-router-dom";
import { PATH_DASHBOARD, PATH_PUBLIC } from "./paths";
import AuthGuard from "../auth/AuthGuard";
import {
  allAccessRoles,
  managerAccessRoles,
  adminAccessRoles,
  ownerAccessRoles,
} from "../auth/auth.utils";
import Layout from "../components/layout";
import AdminPage from "../pages/dashboard/AdminPage";
import DashboardPage from "../pages/dashboard/DashboardPage";
import ManagerPage from "../pages/dashboard/ManagerPage";
import MyLogsPage from "../pages/dashboard/MyLogsPage";
import OwnerPage from "../pages/dashboard/OwnerPage";
import SystemLogsPage from "../pages/dashboard/SystemLogsPage";
import UpdateRolePage from "../pages/dashboard/UpdateRolePage";
import UserPage from "../pages/dashboard/UserPage";
import UsersManagementPage from "../pages/dashboard/UsersManagementPage";
import HomePage from "../pages/public/HomePage";
import LoginPage from "../pages/public/LoginPage";
import NotFoundPage from "../pages/public/NotFoundPage";
import RegisterPage from "../pages/public/RegisterPage";
import UnauthorizedPage from "../pages/public/UnauthorizedPage";
import Products from "../pages/products/Products.page";
import AddProduct from "../pages/products/AddProduct.page";
import EditProduct from "../pages/products/EditProduct.pages";
import DeleteProduct from "../pages/products/DeleteProduct.page";
import Orders from "../pages/orders/Orders.page";
import AddOrders from "../pages/orders/AddOrders.page";
import EditOrder from "../pages/orders/EditOrder.page";
import DeleteOrder from "../pages/orders/DeleteOrder.page";

//implement lazy loading

const GlobalRouter = () => {
  return (
    <Routes>
      {/* <Route path='' element /> */}
      <Route element={<Layout />}>
        {/* Public routes */}
        <Route index element={<HomePage />} />
        <Route path={PATH_PUBLIC.register} element={<RegisterPage />} />
        <Route path={PATH_PUBLIC.login} element={<LoginPage />} />
        <Route path={PATH_PUBLIC.unauthorized} element={<UnauthorizedPage />} />

        {/* Protected routes -------------------------------------------------- */}
        <Route element={<AuthGuard roles={allAccessRoles} />}>
          <Route path={PATH_DASHBOARD.dashboard} element={<DashboardPage />} />
          <Route path={PATH_DASHBOARD.myLogs} element={<MyLogsPage />} />
          <Route path={PATH_DASHBOARD.user} element={<UserPage />} />
          <Route path="/products">
            <Route index element={<Products />} />
            <Route path="add" element={<AddProduct />} />
            <Route path="edit/:id" element={<EditProduct />} />
            <Route path="delete/:id" element={<DeleteProduct />} />
          </Route>
          <Route path="/orders">
            <Route index element={<Orders />} />
            <Route path="add" element={<AddOrders />} />
            <Route path="edit/:id" element={<EditOrder />} />
            <Route path="delete/:id" element={<DeleteOrder />} />
          </Route>
        </Route>
        <Route element={<AuthGuard roles={managerAccessRoles} />}>
          <Route path={PATH_DASHBOARD.manager} element={<ManagerPage />} />
        </Route>
        <Route element={<AuthGuard roles={adminAccessRoles} />}>
          <Route
            path={PATH_DASHBOARD.usersManagement}
            element={<UsersManagementPage />}
          />
          <Route
            path={PATH_DASHBOARD.updateRole}
            element={<UpdateRolePage />}
          />
          <Route
            path={PATH_DASHBOARD.systemLogs}
            element={<SystemLogsPage />}
          />
          <Route path={PATH_DASHBOARD.admin} element={<AdminPage />} />
        </Route>
        <Route element={<AuthGuard roles={ownerAccessRoles} />}>
          <Route path={PATH_DASHBOARD.owner} element={<OwnerPage />} />
        </Route>
        {/* Protected routes -------------------------------------------------- */}

        {/* Catch all (404) */}
        <Route path={PATH_PUBLIC.notFound} element={<NotFoundPage />} />
        <Route
          path="*"
          element={<Navigate to={PATH_PUBLIC.notFound} replace />}
        />
      </Route>
    </Routes>
  );
};

export default GlobalRouter;