using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace LuminaAPI.Model.PMS
{
    public class BrandDetail
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        // Public properties
        public int BrandID { get; set; }

        public string BrandName { get; set; }

        public bool IsActive { get; set; }
    }
}
