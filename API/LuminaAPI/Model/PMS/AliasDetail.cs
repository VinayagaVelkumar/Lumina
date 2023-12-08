using MongoDB.Bson;

namespace LuminaAPI.Model.PMS
{
    public class AliasDetail
    {
        // Private properties
        private int aliasID;
        private string alias;
        private bool isActive;
        private ObjectId id;

        public ObjectId _id
        { get { return id; } }

        // Public properties
        public int AliasID
        {
            get { return this.aliasID; }
            set { this.aliasID = value; }
        }

        public string Alias
        {
            get { return this.alias; }
            set { this.alias = value; }
        }

        public bool IsActive
        {
            get { return this.isActive; }
            set { this.isActive = value; }
        }
    }

}
