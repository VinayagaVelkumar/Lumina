export class Category {
    public categoryID: number;
    public categoryName: string;
    public isActive: boolean;
  
    constructor(
      CategoryID: number,
      CategoryName: string,
      IsActive:boolean
    ) {
      this.categoryID = CategoryID;
      this.categoryName = CategoryName;
      this.isActive = IsActive;
    }
  }