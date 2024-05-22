export interface IProduct {
  id: string;
  brand: string;
  title: string;
  size: string;
}

export interface ICreateProduct {
  brand: string;
  title: string;
  size: string;
}

export interface IOrders {
  id: string;
  total: string;
  address: string;
  paymentMethod: string;
  brand: string;
  productId: string;
  product: string;
  orderDate: string;
  createdAt: string;
  updatedAt: string;
  isActive: string;
  isDeleted: string;
}

export interface ICreateOrders {
  total: string;
  address: string;
  paymentMethod: string;
  productId: string;
  brand: string;
}
