export class ProductList {
    public _id: string;
    public ProductID: string;
    public ProductName: string;
    public Image: string;
    public Price: string;
  
    constructor(
      _id: string,
      ProductID: string,
      ProductName: string,
      Image: string,
      Price:string
    ) {
      this._id = _id;
      this.ProductID = ProductID;
      this.ProductName = ProductName;
      this.Image = Image;
      this.Price = Price;
    }
  }