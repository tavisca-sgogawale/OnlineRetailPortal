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
            var storeEntity = productEntity.ToEntity();          
            try
            {
                var productStoreCollection = _db.GetCollection<MongoEntity>(_collection);
                await productStoreCollection.InsertOneAsync(storeEntity);
            }
            catch
            {
                throw new BaseException(int.Parse(ErrorCode.DataBaseDown()), Error.DataBaseDown(), null, HttpStatusCode.GatewayTimeout);
            }
            return storeEntity.ToModel();
        }

        public async Task<GetProductStoreResponse> GetProductAsync(string productId)
        {
            MongoEntity mongoEntity;
            try
            {
                var productStoreCollection = _db.GetCollection<MongoEntity>(_collection);
                mongoEntity = await productStoreCollection.Find(x => x.Id == productId).FirstAsync();
            }
            catch
            {
                throw new BaseException(int.Parse(ErrorCode.InvalidId()), Error.InvalidId(), null, HttpStatusCode.GatewayTimeout);
            }
            return new GetProductStoreResponse() { Product = mongoEntity.ToModel() };
        }

        public async Task<GetProductsStoreResponse> GetProductsAsync(GetProductsStoreEntity request)
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
            return new GetProductsStoreResponse() { Products = products.ToModel(), PagingInfo = request.PagingInfo };
        }

        public async Task<ProductEntity> UpdateProductAsync(ProductEntity productEntity)
        {
            var mongoEntity = productEntity.ToEntity();
            try
            {
                var productStoreCollection = _db.GetCollection<MongoEntity>(_collection);
                var filter = Builders<MongoEntity>.Filter.Eq("Id", productEntity.Id);
                var result = await productStoreCollection.ReplaceOneAsync(
                filter,
                mongoEntity,
                new UpdateOptions { IsUpsert = false });
                if (result.MatchedCount == 0)
                {
                    throw new BaseException(int.Parse(ErrorCode.InvalidId()), Error.InvalidId(), null, HttpStatusCode.GatewayTimeout);
                }
            }
            catch
            {

                throw new BaseException(int.Parse(ErrorCode.DataBaseDown()), Error.DataBaseDown(), null, HttpStatusCode.GatewayTimeout);

            }

            return mongoEntity.ToModel();
        }
    }
}
