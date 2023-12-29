using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LuminaAPI.Model.UMS
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public ObjectId _id { get; set; }

        // Public properties
        public int UserID { get; set; }

        public string? UserName { get; set; }

        public long MobNumber { get; set; }

        public string? Hash { get; set; }

        public string? Salt { get; set; }
        public bool IsActive { get; set; }
    }

}
