export class SalePAList {
    public _id: string;
    public productID: string;
    public category: string;
    public size: String;
    public color: string;
    public categoryID: number;
    public sizeID: number;
    public colorID: number;
    public tagID:number;
    public tag:string;
    public MRP:number;
    public Discount:number;
    public Count:number;
  
    constructor(
      _id: string,
      productID: string,
      category: string,
      size: string,
      color: string,
      categoryID: number,
      sizeID: number,
      colorID: number,
      tagID:number,
      tag:string,
      mrp:number,
      discount:number,
      count:number
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
      this.MRP = mrp;
      this.Discount = discount;
      this.Count = count;
    }
  }
  