using System.Threading.Tasks;
using OnlineRetailPortal.Contracts;
using MongoDB.Driver;
using System.Collections.Generic;
using MongoDB.Bson;
using OnlineRetailPortal.Mock;
using System;
using OnlineRetailPortal.Core;
using System.Net;
namespace OnlineRetailPortal.MongoDBStore
{
    public class ProductStore : IProductStore
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

        public async Task<ProductEntity> AddProductAsync(ProductEntity productEntity)
        {
            var productStoreCollection = _db.GetCollection<ProductEntity>(_collection);
            try
            {
                await productStoreCollection.InsertOneAsync(productEntity);
            }
            catch
            {
                throw new BaseException(int.Parse(ErrorCode.DataBaseDown()), Error.DataBaseDown(), null, HttpStatusCode.GatewayTimeout);
            }
            return productEntity;
        }


        public Task<GetProductStoreResponse> GetProductAsync(string productId)
        {
            throw new NotImplementedException();
        }

        public Task<GetProductsStoreResponse> GetProductsAsync(GetProductsStoreRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
