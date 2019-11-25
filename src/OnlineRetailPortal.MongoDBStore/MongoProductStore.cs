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
            List<MongoEntity> mongoEntities = new List<MongoEntity>();
            var pageSize = request.PagingInfo.PageSize;
            var pageNumber = request.PagingInfo.PageNumber;
            var collection = _db.GetCollection<MongoEntity>(_collection);
            var sortType = request.ProductSort.Type.ToEntity();
            var skipDocuments = (pageNumber - 1) * pageSize;
            var orderBy = request.ProductSort.Order;

            var sortDefinition = (orderBy == "Asc") ?
                                 (Builders<MongoEntity>.Sort.Ascending(sortType)) :
                                 (Builders<MongoEntity>.Sort.Descending(sortType));

            try
            {
                var docCount = (int)await collection.CountAsync(new BsonDocument());

                request.PagingInfo.TotalPages = (docCount >= pageSize) ?
                                                ((docCount / pageSize) + ((docCount % pageSize) == 0 ? 0 : 1)) : 1;

                var skipDocumentEnabled = (pageNumber - 1 * pageSize) > docCount ? false : true;

                if (skipDocumentEnabled)
                {
                    mongoEntities = await collection.Find(FilterDefinition<MongoEntity>.Empty)
                                                .Skip(skipDocuments)
                                                .Limit(pageSize)
                                                .Sort(sortDefinition)
                                                .ToListAsync();
                }

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

        public async Task<ProductEntity> UpdateProductAsync(UpdateProductEntity updateProductEntity)
        {
            MongoEntity getResult;
            var productStoreCollection = _db.GetCollection<MongoEntity>(_collection);
            getResult = await productStoreCollection.Find(x => x.Id == updateProductEntity.Id).FirstOrDefaultAsync();

            getResult = UpdateProductEntity(await productStoreCollection.Find(x => x.Id == updateProductEntity.Id).FirstOrDefaultAsync(),updateProductEntity);
            var filter = Builders<MongoEntity>.Filter.Eq("Id", updateProductEntity.Id);
            try
            {
                var result = await productStoreCollection.ReplaceOneAsync(
                            filter,
                            getResult,
                            new UpdateOptions { IsUpsert = false });
            }
            catch
            {
                throw new BaseException(int.Parse(ErrorCode.DataBaseDown()), Error.DataBaseDown(), null, HttpStatusCode.GatewayTimeout);
            }
            return getResult.ToModel();
        }

        private MongoEntity UpdateProductEntity(MongoEntity getResult, UpdateProductEntity updateProductEntity)
        {
            if (getResult != null)
            {
                if (updateProductEntity.Name != null)
                {
                    getResult.Name = updateProductEntity.Name;
                }
                if (updateProductEntity.Description != null)
                {
                    getResult.Description = updateProductEntity.Description;
                }
                if (updateProductEntity.Price != null)
                {
                    if (updateProductEntity.Price.Money != null)
                    {
                        getResult.Price.Amount = updateProductEntity.Price.Money.Amount;
                    }
                    if (updateProductEntity.Price.IsNegotiable != null)
                    {
                        getResult.Price.IsNegotiable = Convert.ToBoolean(updateProductEntity.Price.IsNegotiable);
                    }
                }
                if (updateProductEntity.Category != null)
                {
                    getResult.Category = updateProductEntity.Category;
                }
                if (updateProductEntity.Images != null)
                {
                    getResult.Gallery.ImageUrls = updateProductEntity.Images;
                }
                if (updateProductEntity.HeroImage != null)
                {
                    getResult.Gallery.HeroImageUrl = updateProductEntity.HeroImage;
                }
                if (updateProductEntity.PurchasedDate != null)
                {
                    getResult.PurchasedDate = updateProductEntity.PurchasedDate;
                }
                if (updateProductEntity.PickupAddress != null)
                {
                    if (updateProductEntity.PickupAddress.Line1 != null)
                    {
                        getResult.PickupAddress.Line1 = updateProductEntity.PickupAddress.Line1;
                    }
                    if (updateProductEntity.PickupAddress.Line2 != null)
                    {
                        getResult.PickupAddress.Line2 = updateProductEntity.PickupAddress.Line2;
                    }
                    if (updateProductEntity.PickupAddress.State != null)
                    {
                        getResult.PickupAddress.State = updateProductEntity.PickupAddress.State;
                    }
                    if (updateProductEntity.PickupAddress.City != null)
                    {
                        getResult.PickupAddress.City = updateProductEntity.PickupAddress.City;
                    }
                    if (updateProductEntity.PickupAddress.Pincode != 0)
                    {
                        getResult.PickupAddress.Pincode = updateProductEntity.PickupAddress.Pincode;
                    }
                }
                if (updateProductEntity.Status != null)
                {
                    getResult.Status = updateProductEntity.Status;
                }
            }
            return getResult;
        }
    }
}
