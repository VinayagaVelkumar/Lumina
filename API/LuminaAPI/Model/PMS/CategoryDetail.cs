using MongoDB.Bson;

namespace LuminaAPI.Model.PMS
{
    public class CategoryDetail
    {
        // Private properties
        private int categoryID;
        private string categoryName;
        private bool isActive;
        private ObjectId id;

        public ObjectId _id
        { get { return id; } }

        // Public properties
        public int CategoryID
        {
            get { return this.categoryID; }
            set { this.categoryID = value; }
        }

        public string CategoryName
        {
            get { return this.categoryName; }
            set { this.categoryName = value; }
        }

        public bool IsActive
        {
            get { return this.isActive; }
            set { this.isActive = value; }
        }
    }

}
