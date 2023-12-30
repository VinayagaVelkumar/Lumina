namespace LuminaAPI.Model.PRMS
{
    public class BillPAList
    {
        public string _id {  get; set; }

        public string ProductID { get; set; }

        public string Category { get; set; }

        public string Color { get; set; }

        public int Count { get; set; }

        public string Sizes { get; set; }

        public int LastPurchasePrice { get; set; }

        public int EstimatedPrice { get; set; }

        public int EstimatedTotalPrice { get; set; }

        public int CategoryID { get; set; }
    }
}
