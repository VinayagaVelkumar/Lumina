using LuminaAPI.Model.Config;
using LuminaAPI.Model.UMS;
using LuminaAPI.Repository;
using LuminaAPI.Service.Interface;
using MongoDB.Bson;
using MongoDB.Driver;

namespace LuminaAPI.Service
{
    public class UMSService: IUMSService
    {
        private readonly MongoDBHandler<User> dBHandler;
        private readonly CollectionNames _collectionNames;
        private readonly ConnectionConfig _connectionConfig;

        public UMSService(CollectionNames collectionNames, ConnectionConfig connectionConfig)
        {
            this._collectionNames = collectionNames;
            this._connectionConfig = connectionConfig;
            dBHandler = new MongoDBHandler<User>(this._connectionConfig.ConnectionString, this._connectionConfig.DBName, this._collectionNames.User);
        }

        public List<User> GetAll()
        {
            try
            {
                List<User> users = dBHandler.GetAllDocuments();
                return users;
            }
            catch
            {
                throw;
            }
        }


        public User GetByID(string id)
        {
            try
            {
                User userDetail = dBHandler.GetDocumentById(ObjectId.Parse(id));
                return userDetail;
            }
            catch
            {
                throw;
            }
        }

        public bool Insert(User userDetail)
        {
            try
            {
                dBHandler.InsertDocument(userDetail);
                return true;
            }
            catch
            {
                throw;
            }
        }

        public bool Update(User userDetail)
        {
            try
            {
                var filter = Builders<User>.Filter.Eq(p => p._id, userDetail._id);
                var updateUser = Builders<User>.Update.Set(p => p, userDetail);
                dBHandler.UpdateDocument(filter, updateUser);
                return true;
            }
            catch
            {
                throw;
            }
        }
    }
}
