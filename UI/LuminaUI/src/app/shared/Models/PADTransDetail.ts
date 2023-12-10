export class PADTransDetail {
    public _id: string; 
    public PadTransID: number;
    public PadID: number;
    public Count: number;
    public Price: number;
  
    constructor(
      _id: string,
      PadTransID: number,
      PadID: number,
      Count: number,
      Price: number
    ) {
      this._id = _id;
      this.PadTransID = PadTransID;
      this.PadID = PadID;
      this.Count = Count;
      this.Price = Price;
    }
  }
  