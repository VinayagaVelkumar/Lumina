export class Brand {
    public brandID: number;
    public brandName: string;
    public isActive: boolean;
  
    constructor(
      BrandID: number,
      BrandName: string,
      IsActive:boolean
    ) {
      this.brandID = BrandID;
      this.brandName = BrandName;
      this.isActive = IsActive;
    }
  }