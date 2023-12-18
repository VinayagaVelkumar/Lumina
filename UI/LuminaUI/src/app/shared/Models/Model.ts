export class Model {
    public modelID: number;
    public modelName: string;
    public isActive: boolean;
  
    constructor(
      ModelID: number,
      ModelName: string,
      IsActive:boolean
    ) {
      this.modelID = ModelID;
      this.modelName = ModelName;
      this.isActive = IsActive;
    }
  }