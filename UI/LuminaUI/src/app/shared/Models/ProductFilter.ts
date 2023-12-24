export class ProductFilter {
    public categoryID: number;
    public sizeID: number;
    public modelID: number;
  
    constructor(
      categoryID: number,
      sizeID: number,
      modelID: number,
    ) {
      this.categoryID = categoryID;
      this.sizeID = sizeID;
      this.modelID = modelID;
    }
  }
  