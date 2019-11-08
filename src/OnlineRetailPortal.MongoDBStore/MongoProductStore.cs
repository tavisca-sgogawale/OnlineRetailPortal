using MongoDB.Bson;
using MongoDB.Driver;
using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineRetailPortal.MongoDBStore
{
    public class MongoProductStore : IProductStore
    {
        private static MongoClient _dbClient = new MongoClient(new MongoClientSettings
        {
            Server = new MongoServerAddress(MongoDBConfiguration.Url, int.Parse(MongoDBConfiguration.Port)),
            SocketTimeout = new TimeSpan(0, 0, 0, 10),
            WaitQueueTimeout = new TimeSpan(0, 0, 0, 2),
            ConnectTimeout = new TimeSpan(0, 0, 0, 10)
        });
        private IMongoDatabase _db = _dbClient.GetDatabase(MongoDBConfiguration.Database);
        private string _collection = MongoDBConfiguration.ProductCollection;
        public async Task<AddProductStoreResponse> AddProductAsync(AddProductStoreRequest request)
        {
            throw new System.NotImplementedException();
        }

        public async Task<GetProductStoreResponse> GetProductAsync(string request)
        {
            throw new System.NotImplementedException();
        }

        public async Task<GetProductsStoreResponse> GetProductsAsync(GetProductsEntity request)
        {
            var data = _db.GetCollection<Product>(_collection);
            List<Product> products = (await data.FindAsync(new BsonDocument())).ToList();
            return new GetProductsStoreResponse() { Products = products };
        }
    }
}
