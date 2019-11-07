using System.Threading.Tasks;
using OnlineRetailPortal.Contracts;
using MongoDB.Driver;
using System.Collections.Generic;
using MongoDB.Bson;

namespace OnlineRetailPortal.MongoDBStore
{
    public class ProductStore : IProductStore
    {
        private static MongoClient _dbClient = new MongoClient("mongodb://127.0.0.1:27017");
        private IMongoDatabase _db = _dbClient.GetDatabase("ORP");
        private const string _collection = "Product1";

        public async Task<AddProductStoreResponse> AddProductAsync(AddProductStoreRequest request)
        {
            var productStoreCollection = _db.GetCollection<AddProductStoreRequest>(_collection);
            await productStoreCollection.InsertOneAsync(request);
            var filter = Builders<AddProductStoreResponse>.Filter.Eq("SellerId", request.SellerId);
            var productCollection = _db.GetCollection<AddProductStoreResponse>(_collection);
            return (await productCollection.FindAsync(filter)).First();
        }
        public Task<GetProductStoreResponse> GetProductAsync(GetProductStoreRequest request)
        {
            throw new System.NotImplementedException();
        }

        public async Task<GetProductsStoreResponse> GetProductsAsync(GetProductsStoreRequest request)
        {
            throw new System.NotImplementedException();
        }
    }
}
