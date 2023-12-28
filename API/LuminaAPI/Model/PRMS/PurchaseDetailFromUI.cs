namespace LuminaAPI.Model.PRMS
{
    public class PurchaseDetailFromUI
    {
        public string ProductID { get; set; }

        public int CategoryID { get; set; }

        public List<int> SizeIDs { get; set; }

        public int ColorID { get; set; }

        public int MRP { get; set; }

        public int Count { get; set; }

        public int PurchasePrice { get; set; }

        public int DiscountCode { get; set; }

        public int TagID { get; set; }
    }
}
