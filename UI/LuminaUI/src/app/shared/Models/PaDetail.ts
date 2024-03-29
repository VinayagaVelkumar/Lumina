export class PADetail {
    public _id: string;
    public padID: number;
    public productID: number;
    public categoryID: number;
    public sizeID: number;
    public colorCode: number;
    public alias: string;
    public image: string;
    public isActive: boolean;
  
    constructor(
      _id: string,
      padID: number,
      productID: number,
      categoryID: number,
      sizeID: number,
      colorCode: number,
      alias: string,
      image: string,
      isActive: boolean
    ) {
      this._id = _id;
      this.padID = padID;
      this.productID = productID;
      this.categoryID = categoryID;
      this.sizeID = sizeID;
      this.colorCode = colorCode;
      this.alias = alias;
      this.image = image;
      this.isActive = isActive;
    }
  }
  