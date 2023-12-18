using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LuminaAPI.Model.PMS
{
    public class CategoryDetail
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        // Public properties
        public int CategoryID { get; set; }

        public string CategoryName { get; set; }

        public bool IsActive { get; set; }
    }

}
