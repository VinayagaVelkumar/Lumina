export class BillPAList {
    public _id: string;
    public ProductID: string;
    public Category: string;
    public Color: string;
    public Count: number;
    public Sizes: string;
    public LastPurchasePrice: number;
    public estimatedTotalPrice: number;
    public EstimatedTotalPrice: number;
    public CategoryID: number;
  
    constructor(
      _id: string,
      productID: string,
      category: string,
      color: string,
      count: number,
      sizes: string,
      lastPurchasePrice: number,
      estimatedPrice: number,
      estimatedTotalPrice: number,
      categoryID: number
    ) {
      this._id = _id;
      this.ProductID = productID;
      this.Category = category;
      this.Color = color;
      this.Count = count;
      this.Sizes = sizes;
      this.LastPurchasePrice = lastPurchasePrice;
      this.estimatedTotalPrice = estimatedPrice;
      this.EstimatedTotalPrice = estimatedTotalPrice;
      this.CategoryID = categoryID;
    }
  }
  