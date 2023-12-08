using MongoDB.Bson;

namespace LuminaAPI.Model.PMS
{
    public class ProductDetail
    {
        // Private properties
        private string productID;
        private string? productName;
        private string modelID;
        private bool isActive;
        private ObjectId id;

        public ObjectId _id
        { get { return id; } }  

        // Public properties
        public string ProductID
        {
            get { return this.productID; }
            set { this.productID = value; }
        }

        public string? ProductName
        {
            get { return this.productName; }
            set { this.productName = value; }
        }

        public string ModelID
        {
            get { return this.modelID; }
            set { this.modelID = value; }
        }

        public bool IsActive
        {
            get { return this.isActive; }
            set { this.isActive = value; }
        }
    }

}
