﻿using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LuminaAPI.Model.PMS
{
    public class ColorDetail
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; set; }

        // Public properties
        public int ColorID { get; set; }

        public string ColorName { get; set; }

        public bool IsActive { get; set; }
    }

}
