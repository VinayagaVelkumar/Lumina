using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace LuminaAPI.Model.PMS
{
    public class PADetail
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string _id { get; private set; }

        public string ProductID { get; set; }

        public int CategoryID { get; set; }

        public int SizeID { get; set; }

        public int ColorID { get; set; }

        public string Image { get; set; }

        public bool IsActive { get; set; }

        public int TagID { get; set; }
    }
    }

    public class ProductList
    {
        private string productID;
        private string image;
        private int price;

        public string ProductID
        {
            get { return this.productID; }
            set { this.productID = value; }
        }

        public string Image
        {
            get { return this.image; }
            set { this.image = value; }
        }

        public int Price
        {
            get { return this.price; }
            set { this.price = value; }
        }

    }
