using MongoDB.Bson;
using MongoDB.Driver;

namespace LuminaAPI.Repository
{
    public class MongoDBHandler<T>
    {
        private readonly IMongoCollection<T> collection;

        public MongoDBHandler(string connectionString, string databaseName, string collectionName)
        {
            var client = new MongoClient(connectionString);
            var database = client.GetDatabase(databaseName);
            collection = database.GetCollection<T>(collectionName);
        }

        public void InsertDocument(T document)
        {
            try
            {
            collection.InsertOne(document);
            }
            catch
            {
                throw;
            }
        }

        public void UpdateDocument(FilterDefinition<T> filter, UpdateDefinition<T> update)
        {
            try
            {
            collection.UpdateOne(filter, update);
            }
            catch
            {
                throw;
            }
        }

        public List<T> GetAllDocuments()
        {
            try
            {
            return collection.Find(new BsonDocument()).ToList();
            }
            catch
            {
                throw;
            }
        }

        public T GetDocumentById(ObjectId id)
        {
            try
            {
            var filter = Builders<T>.Filter.Eq("_id", id);
            var document = collection.Find(filter).FirstOrDefault();
            return document;
            }
            catch
            {
                throw;
            }
        }
    }
}
