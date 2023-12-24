export class PAList {
    public _id: string;
    public productID: number;
    public Category: string;
    public Size: String;
    public Color: string;
    public categoryID: number;
    public sizeID: number;
    public colorID: number;
    public tagID:number;
    public tag:string;
  
    constructor(
      _id: string,
      productID: number,
      category: string,
      size: string,
      color: string,
      categoryID: number,
      sizeID: number,
      colorID: number,
      tagID:number,
      tag:string
    ) {
      this._id = _id;
      this.productID = productID;
      this.Category = category;
      this.Size = size;
      this.Color = color;
      this.categoryID = categoryID;
      this.sizeID = sizeID;
      this.colorID = colorID;
      this.tag = tag;
      this.tagID = tagID;
    }
  }
  