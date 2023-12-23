export class PAList {
    public _id: string;
    public productID: number;
    public Category: string;
    public Size: String;
    public Color: string;
  
    constructor(
      _id: string,
      productID: number,
      category: string,
      size: string,
      color: string
    ) {
      this._id = _id;
      this.productID = productID;
      this.Category = category;
      this.Size = size;
      this.Color = color;
    }
  }
  