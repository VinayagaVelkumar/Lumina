using MongoDB.Bson;

namespace LuminaAPI.Model.PMS
{
    public class ColorDetail
    {
        // Private properties
        private int colorCode;
        private string colorName;
        private int aliasID;
        private bool isActive;
        private ObjectId id;

        public ObjectId _id
        { get { return id; } }

        // Public properties
        public int ColorCode
        {
            get { return this.colorCode; }
            set { this.colorCode = value; }
        }

        public string ColorName
        {
            get { return this.colorName; }
            set { this.colorName = value; }
        }

        public int AliasID
        {
            get { return this.aliasID; }
            set { this.aliasID = value; }
        }

        public bool IsActive
        {
            get { return this.isActive; }
            set { this.isActive = value; }
        }
    }

}
