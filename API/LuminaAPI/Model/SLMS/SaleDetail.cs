using MongoDB.Bson;

namespace LuminaAPI.Model.SLMS
{
    public class SaleDetail
    {
        // Private properties
        private int saleID;
        private int productID;
        private int padID;
        private DateTime saleDate;
        private int count;
        private int soldPrice;
        private int mrp;
        private int userID;
        private int purchasedPrice;
        private ObjectId id;

        public ObjectId _id
        { get { return id; } }

        // Public properties
        public int SaleID
        {
            get { return this.saleID; }
            set { this.saleID = value; }
        }

        public int ProductID
        {
            get { return this.productID; }
            set { this.productID = value; }
        }

        public int PadID
        {
            get { return this.padID; }
            set { this.padID = value; }
        }

        public DateTime SaleDate
        {
            get { return this.saleDate; }
            set { this.saleDate = value; }
        }

        public int Count
        {
            get { return this.count; }
            set { this.count = value; }
        }

        public int SoldPrice
        {
            get { return this.soldPrice; }
            set { this.soldPrice = value; }
        }

        public int MRP
        {
            get { return this.mrp; }
            set { this.mrp = value; }
        }

        public int UserID
        {
            get { return this.userID; }
            set { this.userID = value; }
        }

        public int PurchasedPrice
        {
            get { return this.purchasedPrice; }
            set { this.purchasedPrice = value; }
        }
    }

}
