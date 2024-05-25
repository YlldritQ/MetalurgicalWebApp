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

export interface IOrder {
  total: string;
  address: string;
  paymentMethod: string;
  productId: string;
  brand: string;
}
