using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LuminaAPI.Model.PMS
{
    public class ProductDetail
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get;set; }

        // Public properties
        public string ProductID { get; set; }

        public string? ProductName { get; set; }

        public bool IsActive { get; set; }

        public int BrandID { get; set; }

        public int ModelID { get; set; }

        [BsonIgnore]
        public string Brand {  get; set; }

        [BsonIgnore]
        public string Model {  get; set; }  
    }

}
