using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace LuminaAPI.Model.PMS
{
    public class TagDetail
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        // Public properties
        public int TagID { get; set; }

        public string TagName { get; set; }

        public bool IsActive { get; set; }
    }
}
