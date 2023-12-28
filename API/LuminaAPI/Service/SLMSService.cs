using LuminaAPI.Model.Config;
using LuminaAPI.Model.SLMS;
using LuminaAPI.Repository;
using LuminaAPI.Service.Interface;
using MongoDB.Bson;
using MongoDB.Driver;

namespace LuminaAPI.Service
{
    public class SLMSService : ISLMSService
    {
        private readonly MongoDBHandler<SaleDetail> dBHandler;
        private readonly CollectionNames _collectionNames;
        private readonly ConnectionConfig _connectionConfig;

        public SLMSService(CollectionNames collectionNames, ConnectionConfig connectionConfig)
        {
            this._collectionNames = collectionNames;
            this._connectionConfig = connectionConfig;
            dBHandler = new MongoDBHandler<SaleDetail>(this._connectionConfig.ConnectionString, this._connectionConfig.DBName, this._collectionNames.Sale);
        }

        public List<SaleDetail> GetAll()
        {
            try
            {
                List<SaleDetail> sales = dBHandler.GetAllDocuments();
                return sales;
            }
            catch
            {
               
                throw;
            }
        }


        public SaleDetail GetByID(string id)
        {
            try
            {
                SaleDetail saleDetail = dBHandler.GetDocumentById(ObjectId.Parse(id));
                return saleDetail;
            }
            catch
            {
                throw;
            }
        }

        public bool Insert(SaleDetail saleDetail)
        {
            try
            {
                dBHandler.InsertDocument(saleDetail);
                return true;
            }
            catch
            {
                throw;
            }
        }

        public bool Update(SaleDetail saleDetail)
        {
            try
            {
                var filter = Builders<SaleDetail>.Filter.Eq(p => p._id, saleDetail._id);
                var updateSale = Builders<SaleDetail>.Update.Set(p => p.Count, saleDetail.Count);
                dBHandler.UpdateDocument(filter, updateSale);
                return true;
            }
            catch
            {
                throw;
            }
        }
    }
}
