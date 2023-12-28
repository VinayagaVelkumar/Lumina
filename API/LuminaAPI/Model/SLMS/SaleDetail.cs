using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LuminaAPI.Model.SLMS
{
    public class SaleDetail
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        public string ProductID { get; set; }

        public string PadID { get; set; }

        public DateTime SaleDate { get; set; }

        public int Count { get; set; }

        public int PreviousCount { get; set; }

        public int SoldPrice { get; set; }

        public int MRP { get; set; }

        public int UserID { get; set; }

        public int PurchasedPrice { get; set; }
    }

}
