using MongoDB.Bson;

namespace LuminaAPI.Model.PMS
{
    public class SizeDetail
    {
        // Private properties
        private int sizeID;
        private int size;
        private int categoryID;
        private bool isActive;
        private ObjectId id;

        public ObjectId _id
        { get { return id; } }

        // Public properties
        public int SizeID
        {
            get { return this.sizeID; }
            set { this.sizeID = value; }
        }

        public int Size
        {
            get { return this.size; }
            set { this.size = value; }
        }

        public int CategoryID
        {
            get { return this.categoryID; }
            set { this.categoryID = value; }
        }

        public bool IsActive
        {
            get { return this.isActive; }
            set { this.isActive = value; }
        }
    }

}
