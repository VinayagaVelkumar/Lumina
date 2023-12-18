export class ProductList {
    public productID: string;
    public image: string;
    public price: string;
  
    constructor(
      ProductID: string,
      Image: string,
      Price:string
    ) {
      this.productID = ProductID;
      this.image = Image;
      this.price = Price;
    }
  }