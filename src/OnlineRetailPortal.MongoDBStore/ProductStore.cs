using MongoDB.Bson;
using MongoDB.Driver;
using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineRetailPortal.MongoDBStore
{
    public class ProductStore : IProductStore
    {
        private static MongoClient _dbClient = new MongoClient(new MongoClientSettings
        {
            Server = new MongoServerAddress("mongodb://127.0.0.1"),
            SocketTimeout = new TimeSpan(0, 0, 0, 2),
            WaitQueueTimeout = new TimeSpan(0, 0, 0, 2),
            ConnectTimeout = new TimeSpan(0, 0, 0, 2),

        });
        private IMongoDatabase _db = _dbClient.GetDatabase("ORP");
        private const string _collection = "Product";
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
            GetProductsStoreResponse getProductsStoreResponse = new GetProductsStoreResponse();
            var data = _db.GetCollection<Product>(_collection);
            List<Product> products = (await data.FindAsync(new BsonDocument())).ToList();
            getProductsStoreResponse.Products = products;
            return getProductsStoreResponse;
        }
    }
}
