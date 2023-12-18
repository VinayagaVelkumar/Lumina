export class Product {
    public productID: number;
    public productName: string;
    public isActive: boolean;
  
    constructor(
      ProductID: number,
      ProductName: string,
      IsActive:boolean
    ) {
      this.productID = ProductID;
      this.productName = ProductName;
      this.isActive = IsActive;
    }
  }