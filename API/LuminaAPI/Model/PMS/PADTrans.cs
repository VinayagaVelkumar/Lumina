using MongoDB.Bson;

namespace LuminaAPI.Model.PMS
{
    public class PADTrans
    {
        // Private properties
        private int padTransID;
        private int padID;
        private int count;
        private int price;
        private ObjectId id;

        public ObjectId _id
        { get { return id; } }

        // Public properties
        public int PadTransID
        {
            get { return this.padTransID; }
            set { this.padTransID = value; }
        }

        public int PadID
        {
            get { return this.padID; }
            set { this.padID = value; }
        }

        public int Count
        {
            get { return this.count; }
            set { this.count = value; }
        }

        public int Price
        {
            get { return this.price; }
            set { this.price = value; }
        }
    }

}
