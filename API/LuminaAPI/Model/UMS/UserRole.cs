using MongoDB.Bson;

namespace LuminaAPI.Model.UMS
{
    public class UserRole
    {
        // Private properties
        private int roleID;
        private string? roleName;
        private bool isActive;
        private ObjectId id;

        public ObjectId _id
        { get { return id; } }

        // Public properties
        public int RoleID
        {
            get { return roleID; }
            set { roleID = value; }
        }

        public string? RoleName
        {
            get { return roleName; }
            set { roleName = value; }
        }

        public bool IsActive
        {
            get { return isActive; }
            set { isActive = value; }
        }
    }

}
