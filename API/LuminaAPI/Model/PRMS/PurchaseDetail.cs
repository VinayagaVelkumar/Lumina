using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LuminaAPI.Model.PRMS
{
    public class PurchaseDetail
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id {  get; set; }

        // Public properties
        public int PurchaseID { get; set; }

        public int ProductID { get; set; }

        public string PadID { get; set; }

        public DateTime PurchaseDate { get; set; }

        public int Count { get; set; }

        public int PurchasePrice { get; set; }

        public int DiscountCode { get; set; }

        public int PrevCount { get; set; }

        public int CurrentCount { get; set; }

        public int MRP { get; set; }
    }

}
