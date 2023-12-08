using LuminaAPI.Model.Config;
using LuminaAPI.Model.PRMS;
using LuminaAPI.Repository;
using LuminaAPI.Service.Interface;
using MongoDB.Bson;
using MongoDB.Driver;

namespace LuminaAPI.Service
{
    public class PRMSService : IPRMSService
    {
        private readonly MongoDBHandler<PurchaseDetail> dBHandler;
        private readonly CollectionNames _collectionNames;
        private readonly ConnectionConfig _connectionConfig;

        public PRMSService(CollectionNames collectionNames, ConnectionConfig connectionConfig)
        {
            this._collectionNames = collectionNames;
            this._connectionConfig = connectionConfig;
            dBHandler = new MongoDBHandler<PurchaseDetail>(this._connectionConfig.ConnectionString, this._connectionConfig.DBName, this._collectionNames.Product);
        }

        public List<PurchaseDetail> GetAll()
        {
            try
            {
                List<PurchaseDetail> products = dBHandler.GetAllDocuments();
                return products;
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                return null;
            }
        }


        public PurchaseDetail GetByID(string id)
        {
            try
            {
                PurchaseDetail productDetail = dBHandler.GetDocumentById(ObjectId.Parse(id));
                return productDetail;
            }
            catch
            {
                return null;
            }
        }

        public bool Insert(PurchaseDetail prDetail)
        {
            try
            {
                dBHandler.InsertDocument(prDetail);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Update(PurchaseDetail prDetail)
        {
            try
            {
                var filter = Builders<PurchaseDetail>.Filter.Eq(p => p._id, prDetail._id);
                var updatePrDetail = Builders<PurchaseDetail>.Update.Set(p => p, prDetail);
                dBHandler.UpdateDocument(filter, updatePrDetail);
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
