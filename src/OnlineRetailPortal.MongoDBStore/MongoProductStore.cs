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
            var productStoreCollection = _db.GetCollection<MongoEntity>(_collection);
            try
            {
                await productStoreCollection.InsertOneAsync(storeEntity);
            }
            catch (MongoWriteException mongoWriteException)
            {
                if (mongoWriteException.WriteError.Category == ServerErrorCategory.DuplicateKey)
                {
                    throw new BaseException(int.Parse(ErrorCode.DuplicateProduct()), Error.DuplicateProduct(), null, HttpStatusCode.GatewayTimeout);
                }
            }
            var mongoEntity = (await productStoreCollection.Find(_ => _.Id == productEntity.Id).FirstOrDefaultAsync()).ToModel();
            return mongoEntity;
        }

        public async Task<GetProductStoreResponse> GetProductAsync(string productId)
        {
            MongoEntity mongoEntity;
            var productStoreCollection = _db.GetCollection<MongoEntity>(_collection);
            try
            {
                mongoEntity = await productStoreCollection.Find(x => x.Id == productId).FirstOrDefaultAsync();
            }
            catch
            {
                throw new BaseException(int.Parse(ErrorCode.DataBaseDown()), Error.DataBaseDown(), null, HttpStatusCode.GatewayTimeout);
            }
            return mongoEntity.ToGetResponseModel();
        }

        public async Task<GetProductsStoreResponse> GetProductsAsync(GetProductsStoreEntity request)
        {
            List<MongoEntity> mongoEntities;
            var pageSize = request.PagingInfo.PageSize;
            var pageNumber = request.PagingInfo.PageNumber;
            var collection = _db.GetCollection<MongoEntity>(_collection);
            var sortDefinition = Builders<MongoEntity>.Sort.Ascending(request.ProductSort.Type);
            try
            {
                if (request.ProductSort.Order == "Asc")            // for ascending order
                {
                    sortDefinition = Builders<MongoEntity>.Sort.Ascending(request.ProductSort.Type);
                }
                else
                {
                    sortDefinition = Builders<MongoEntity>.Sort.Ascending(request.ProductSort.Type);
                }


                mongoEntities = await collection.Find(FilterDefinition<MongoEntity>.Empty)
                                                .Skip(pageNumber - 1)
                                                .Limit(pageSize)
                                                .Sort(sortDefinition)
                                                .ToListAsync();

                var docCount = await collection.CountAsync(new BsonDocument());
                request.PagingInfo.TotalPages = (int)docCount;
            }
            catch
            {
                throw new BaseException(int.Parse(ErrorCode.DataBaseDown()), Error.DataBaseDown(), null, HttpStatusCode.GatewayTimeout);
            }
            return mongoEntities.ToModel(request.PagingInfo);
        }

        public async Task<ProductEntity> UpdateProductAsync(ProductEntity productEntity)
        {
            var mongoEntity = productEntity.ToEntity();
            var productStoreCollection = _db.GetCollection<MongoEntity>(_collection);
            var filter = Builders<MongoEntity>.Filter.Eq("Id", productEntity.Id);
            var result = await productStoreCollection.ReplaceOneAsync(
                            filter,
                            mongoEntity,
                            new UpdateOptions { IsUpsert = false });

            if (result.MatchedCount == 0)
            {
                return null;
            }
            return mongoEntity.ToModel();
        }
    }
}
