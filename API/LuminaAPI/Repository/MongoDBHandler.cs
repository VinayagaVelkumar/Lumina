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
            collection.InsertOne(document);
        }

        public void UpdateDocument(FilterDefinition<T> filter, UpdateDefinition<T> update)
        {
            collection.UpdateOne(filter, update);
        }

        public List<T> GetAllDocuments()
        {
            return collection.Find(new BsonDocument()).ToList();
        }

        public T GetDocumentById(ObjectId id)
        {
            var filter = Builders<T>.Filter.Eq("_id", id);
            var document = collection.Find(filter).FirstOrDefault();
            return document;
        }
    }
}
