using MongoDB.Bson;

namespace LuminaAPI.Model.PRMS
{
    public class PurchaseDetail
    {
        // Private properties
        private int purchaseID;
        private int productID;
        private int padID;
        private DateTime purchaseDate;
        private int count;
        private int purchasePrice;
        private int discountCode;
        private int mrp;
        private ObjectId id;

        public ObjectId _id
        { get { return id; } }

        // Public properties
        public int PurchaseID
        {
            get { return this.purchaseID; }
            set { this.purchaseID = value; }
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

        public DateTime PurchaseDate
        {
            get { return this.purchaseDate; }
            set { this.purchaseDate = value; }
        }

        public int Count
        {
            get { return this.count; }
            set { this.count = value; }
        }

        public int PurchasePrice
        {
            get { return this.purchasePrice; }
            set { this.purchasePrice = value; }
        }

        public int DiscountCode
        {
            get { return this.discountCode; }
            set { this.discountCode = value; }
        }

        public int MRP
        {
            get { return this.mrp; }
            set { this.mrp = value; }
        }
    }

}
