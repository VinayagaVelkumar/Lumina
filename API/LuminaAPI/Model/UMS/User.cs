using MongoDB.Bson;

namespace LuminaAPI.Model.UMS
{
    public class User
    {
        // Private properties
        private int userID;
        private string? userName;
        private int mobNumber;
        private string? hash;
        private string? salt;
        private bool isActive;
        private ObjectId id;

        public ObjectId _id
        { get { return id; } }

        // Public properties
        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        public string? UserName
        {
            get { return userName; }
            set { userName = value; }
        }

        public int MobNumber
        {
            get { return mobNumber; }
            set { mobNumber = value; }
        }

        public string? Hash
        {
            get { return hash; }
            set { hash = value; }
        }

        public string? Salt
        {
            get { return salt; }
            set { salt = value; }
        }

        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }
    }

}
