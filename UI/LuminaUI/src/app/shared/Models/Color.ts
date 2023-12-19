export class Color {
    public colorID: number;
    public colorName: string;
    public isActive: boolean;
  
    constructor(
      ColorID: number,
      ColorName: string,
      IsActive:boolean
    ) {
      this.colorID = ColorID;
      this.colorName = ColorName;
      this.isActive = IsActive;
    }
  }