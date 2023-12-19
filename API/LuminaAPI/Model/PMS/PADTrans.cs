using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LuminaAPI.Model.PMS
{
    public class PADTrans
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }
        public int PadTransID { get; set; }
        public string PadID { get; set; }
        public int Count { get; set; }
        public int Price { get; set; }

        public int MRP { get; set; }
    }

}
