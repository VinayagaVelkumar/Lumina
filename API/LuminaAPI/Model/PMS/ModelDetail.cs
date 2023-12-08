using MongoDB.Bson;

namespace LuminaAPI.Model.PMS
{
    public class ModelDetail
    {
        // Private properties
        private int modelID;
        private string modelName;
        private bool isActive;
        private ObjectId id;

        public ObjectId _id
        { get { return id; } }

        // Public properties
        public int ModelID
        {
            get { return this.modelID; }
            set { this.modelID = value; }
        }

        public string ModelName
        {
            get { return this.modelName; }
            set { this.modelName = value; }
        }

        public bool IsActive
        {
            get { return this.isActive; }
            set { this.isActive = value; }
        }
    }

}
