export class ProductList {
    public ProductID: string;
    public Image: string;
    public Price: string;
  
    constructor(
      ProductID: string,
      Image: string,
      Price:string
    ) {
      this.ProductID = ProductID;
      this.Image = Image;
      this.Price = Price;
    }
  }