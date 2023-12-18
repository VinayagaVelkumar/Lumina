export class Size {
    public sizeID: number;
    public size: Number;
    public categoryID: Number;
    public isActive: boolean;
  
    constructor(
      SizeID: number,
      Size: Number,
      CategoryID: Number,
      IsActive:boolean
    ) {
      this.sizeID = SizeID;
      this.size = Size;
      this.categoryID = CategoryID;
      this.isActive = IsActive;
    }
  }