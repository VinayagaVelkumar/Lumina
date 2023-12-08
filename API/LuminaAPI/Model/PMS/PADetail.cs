using MongoDB.Bson;

namespace LuminaAPI.Model.PMS
{
    public class PADetail
    {
        // Private properties
        private int padID;
        private int productID;
        private int categoryID;
        private int sizeID;
        private int colorCode;
        private string alias;
        private string imageURL;
        private bool isActive;
        private ObjectId id;

        public ObjectId _id
        { get { return id; } }

        // Public properties
        public int PadID
        {
            get { return this.padID; }
            set { this.padID = value; }
        }

        public int ProductID
        {
            get { return this.productID; }
            set { this.productID = value; }
        }

        public int CategoryID
        {
            get { return this.categoryID; }
            set { this.categoryID = value; }
        }

        public int SizeID
        {
            get { return this.sizeID; }
            set { this.sizeID = value; }
        }

        public int ColorCode
        {
            get { return this.colorCode; }
            set { this.colorCode = value; }
        }

        public string Alias
        {
            get { return this.alias; }
            set { this.alias = value; }
        }

        public string ImageURL
        {
            get { return this.imageURL; }
            set { this.imageURL = value; }
        }

        public bool IsActive
        {
            get { return this.isActive; }
            set { this.isActive = value; }
        }
    }

}
