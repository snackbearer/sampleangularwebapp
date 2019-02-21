export class Product {
  public constructor(init?: Partial<Product>) {
    Object.assign(this, init);
  }

  productId: number;
  productCode: string;
  productName: string;
  productCost: number;
}
