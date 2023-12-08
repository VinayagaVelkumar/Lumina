using MongoDB.Bson;

namespace LuminaAPI.Model.UMS
{
    public class UserRoleTrans
    {
        // Private properties
        private int urtID;
        private int roleID;
        private int userID;
        private DateTime createdDate;
        private bool isActive;
        private ObjectId id;

        public ObjectId _id
        { get { return id; } }

        // Public properties
        public int URTID
        {
            get { return urtID; }
            set { urtID = value; }
        }

        public int RoleID
        {
            get { return roleID; }
            set { roleID = value; }
        }

        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        public DateTime CreatedDate
        {
            get { return createdDate; }
            set { createdDate = value; }
        }

        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }
    }

}
