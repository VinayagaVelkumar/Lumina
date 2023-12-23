export class Product {
    public _id: string | null;
    public productID: string;
    public productName: string;
    public isActive: boolean;
    public brandID: number;
    public modelID: number;
    public brand: string;
    public model: string;

    constructor(
      Id: string | null,
      ProductID: string,
      ProductName: string,
      IsActive:boolean,
      BrandID: number,
      ModelID: number,
      Brand: string,
      Model: string,
      Image?: string | null

    ) {
      this._id = Id;
      this.productID = ProductID;
      this.productName = ProductName;
      this.isActive = IsActive;
      this.brandID = BrandID;
      this.modelID = ModelID;
      this.brand = Brand;
      this.model = Model;
    }
  }