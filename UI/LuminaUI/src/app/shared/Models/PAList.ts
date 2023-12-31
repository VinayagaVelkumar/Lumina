export class PAList {
    public _id: string;
    public productID: number;
    public category: string;
    public size: string;
    public color: string;
    public categoryID: number;
    public sizeID: number;
    public colorID: number;
    public tagID:number;
    public tag:string;
    public addedToBill:boolean
  
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
      tag:string,
      AddedToBill:boolean
    ) {
      this._id = _id;
      this.productID = productID;
      this.category = category;
      this.size = size;
      this.color = color;
      this.categoryID = categoryID;
      this.sizeID = sizeID;
      this.colorID = colorID;
      this.tag = tag;
      this.tagID = tagID;
      this.addedToBill = AddedToBill
    }
  }
  