using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LuminaAPI.Model.PMS
{
    public class SizeDetail
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id {  get; set; }

        // Public properties
        public int SizeID { get; set; }

        public int Size { get; set; }

        public int CategoryID { get; set; }

        public bool IsActive { get; set; }
    }

}
