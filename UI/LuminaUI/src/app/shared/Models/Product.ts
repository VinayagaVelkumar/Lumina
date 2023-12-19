export class Product {
    public productID: number;
    public productName: string;
    public isActive: boolean;
    public brandID: number;
    public modelID: number;
    public brand: string;
    public model: string;
  
    constructor(
      ProductID: number,
      ProductName: string,
      IsActive:boolean,
      BrandID: number,
      ModelID: number,
      Brand: string,
      Model: string

    ) {
      this.productID = ProductID;
      this.productName = ProductName;
      this.isActive = IsActive;
      this.brandID = BrandID;
      this.modelID = ModelID;
      this.brand = Brand;
      this.model = Model;
    }
  }