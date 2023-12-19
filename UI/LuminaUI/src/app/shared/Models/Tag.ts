export class Tag {
    public tagID: number;
    public tagName: string;
    public isActive: boolean;
  
    constructor(
      TagID: number,
      TagName: string,
      IsActive:boolean
    ) {
      this.tagID = TagID;
      this.tagName = TagName;
      this.isActive = IsActive;
    }
  }