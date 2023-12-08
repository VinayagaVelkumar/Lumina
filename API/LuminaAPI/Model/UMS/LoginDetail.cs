using MongoDB.Bson;

namespace LuminaAPI.Model.UMS
{
    public class LoginDetail
    {
        // Private properties
        private int ldID;
        private int userID;
        private DateTime loginDate;
        private TimeSpan loginTime;
        private DateTime logoutDate;
        private TimeSpan logoutTime;
        private ObjectId id;

        public ObjectId _id
        { get { return id; } }

        // Public properties
        public int LdID
        {
            get { return ldID; }
            set { ldID = value; }
        }

        public int UserID
        {
            get { return userID; }
            set { userID = value; }
        }

        public DateTime LoginDate
        {
            get { return loginDate; }
            set { loginDate = value; }
        }

        public TimeSpan LoginTime
        {
            get { return loginTime; }
            set { loginTime = value; }
        }

        public DateTime LogoutDate
        {
            get { return logoutDate; }
            set { logoutDate = value; }
        }

        public TimeSpan LogoutTime
        {
            get { return logoutTime; }
            set { logoutTime = value; }
        }
    }
}
