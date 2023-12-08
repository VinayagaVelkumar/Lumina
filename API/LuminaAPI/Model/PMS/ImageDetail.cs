using MongoDB.Bson;

namespace LuminaAPI.Model.PMS
{
    public class ImageDetail
    {
        // Private properties
        private int imageID;
        private string imageURL;
        private int padID;
        private bool isActive;
        private ObjectId id;

        public ObjectId _id
        { get { return id; } }

        // Public properties
        public int ImageID
        {
            get { return this.imageID; }
            set { this.imageID = value; }
        }

        public string ImageURL
        {
            get { return this.imageURL; }
            set { this.imageURL = value; }
        }

        public int PadID
        {
            get { return this.padID; }
            set { this.padID = value; }
        }

        public bool IsActive
        {
            get { return this.isActive; }
            set { this.isActive = value; }
        }
    }
}
