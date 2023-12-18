using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LuminaAPI.Model.PMS
{
    public class ModelDetail
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        // Public properties
        public int ModelID { get; set; }

        public string ModelName { get; set; }

        public bool IsActive { get; set; }
    }

}
