using MongoDB.Bson;
using MongoDB.Driver;
using OnlineRetailPortal.Contracts;
using OnlineRetailPortal.Core;
using System;
using System.Collections.Generic;
using System.Net;
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

        public async Task<ProductEntity> AddProductAsync(ProductEntity productEntity)
        {
            var mongoEntity = productEntity.ToEntity();
            var productStoreCollection = _db.GetCollection<MongoEntity>(_collection);
            try
            {
                await productStoreCollection.InsertOneAsync(mongoEntity);
            }
            catch
            {
                throw new BaseException(int.Parse(ErrorCode.DataBaseDown()), Error.DataBaseDown(), null, HttpStatusCode.GatewayTimeout);
            }
            return mongoEntity.ToModel();
        }


        public async Task<ProductStoreResult> GetProductAsync(string productId)
        {
            MongoEntity product;
            try
            {
                var productStoreCollection = _db.GetCollection<MongoEntity>(_collection);
                product = await productStoreCollection.Find(x => x.Id == productId).FirstAsync();
            }
            catch
            {
                throw new BaseException(int.Parse(ErrorCode.DataBaseDown()), Error.DataBaseDown(), null, HttpStatusCode.GatewayTimeout);
            }
            return new ProductStoreResult() { Product = product.ToModel() };
        }

        public async Task<ProductStoreResults> GetProductsAsync(SearchQuery query)
        {
            List<MongoEntity> products;
            try
            {
                var sort = Builders<MongoEntity>.Sort.Descending("PostDateTime");

                var data = _db.GetCollection<MongoEntity>(_collection);
                products = await data.Find(new BsonDocument())
                                        .Sort(sort)
                                        .ToListAsync();
            }
            catch
            {
                throw new BaseException(int.Parse(ErrorCode.DataBaseDown()), Error.DataBaseDown(), null, HttpStatusCode.GatewayTimeout);
            }
            return new ProductStoreResults() { Products = products.ToModel(), PagingInfo = query.PagingInfo };
        }
    }
}
