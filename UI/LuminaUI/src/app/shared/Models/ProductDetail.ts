export class ProductDetail {
    public _id: string;
    public ProductID: string;
    public ProductName: string;
    public ModelID: string;
    public IsActive: boolean;
  
    constructor(
      _id: string,
      ProductID: string,
      ProductName: string,
      ModelID: string,
      IsActive: boolean,
    ) {
      this._id = _id;
      this.ProductID = ProductID;
      this.ProductName = ProductName;
      this.ModelID = ModelID;
      this.IsActive = IsActive;
    }
  }
  