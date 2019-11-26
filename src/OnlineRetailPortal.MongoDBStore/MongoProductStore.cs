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
        private bool ValidatePickupAddress(MongoEntity updateProductEntity)
        {
            if(updateProductEntity.PickupAddress.Line1 != null && updateProductEntity.PickupAddress.City != null && updateProductEntity.PickupAddress.State != null && updateProductEntity.PickupAddress.Pincode > 0)
            {
                return true;
            }
            return false;
        }
        private bool ValidatePickupAddress(UpdateProductEntity updateProductEntity)
        {
            if (updateProductEntity.PickupAddress.Line1 != null && updateProductEntity.PickupAddress.City != null && updateProductEntity.PickupAddress.State != null && updateProductEntity.PickupAddress.Pincode > 0)
            {
                return true;
            }
            return false;
        }
        private MongoEntity UpdateProductEntity(MongoEntity getResult, UpdateProductEntity updateProductEntity)
        {
            if (getResult != null)
            {
                getResult.Name = updateProductEntity.Name ?? getResult.Name;
                getResult.Description = updateProductEntity.Description ?? getResult.Description;
                getResult.Category = updateProductEntity.Category ?? getResult.Category;



                getResult.Gallery.ImageUrls = (updateProductEntity.Images != null) ?
                                                    updateProductEntity.Images : getResult.Gallery.ImageUrls;
                getResult.Price.Amount = (updateProductEntity.Price != null) ?
                                                 (updateProductEntity.Price.Money != null) ?
                                                        updateProductEntity.Price.Money.Amount : getResult.Price.Amount
                                          : getResult.Price.Amount;
                getResult.Price.IsNegotiable = (updateProductEntity.Price != null) ?
                                                    (updateProductEntity.Price.IsNegotiable != null) ?
                                                            Convert.ToBoolean(updateProductEntity.Price.IsNegotiable) : getResult.Price.IsNegotiable
                                                : getResult.Price.IsNegotiable;
                getResult.Gallery.HeroImageUrl = (updateProductEntity.HeroImage != null) ?
                                                        updateProductEntity.HeroImage : getResult.Gallery.HeroImageUrl;
                getResult.PurchasedDate = updateProductEntity.PurchasedDate ?? getResult.PurchasedDate;

                if (updateProductEntity.PickupAddress != null)
                {
                    if(ValidatePickupAddress(getResult))
                    {
                        getResult.PickupAddress.Line1 = updateProductEntity.PickupAddress.Line1 ?? getResult.PickupAddress.Line1;
                        getResult.PickupAddress.Line2 = updateProductEntity.PickupAddress.Line2 ?? getResult.PickupAddress.Line2;
                        getResult.PickupAddress.State = updateProductEntity.PickupAddress.State ?? getResult.PickupAddress.State;
                        getResult.PickupAddress.City = updateProductEntity.PickupAddress.City ?? getResult.PickupAddress.City;
                        getResult.PickupAddress.Pincode = (updateProductEntity.PickupAddress.Pincode != 0) ?
                                                                updateProductEntity.PickupAddress.Pincode : getResult.PickupAddress.Pincode;
                    }
                    else
                    {
                        if (ValidatePickupAddress(updateProductEntity))
                        {
                            getResult.PickupAddress.Line1 = updateProductEntity.PickupAddress.Line1;
                            getResult.PickupAddress.Line2 = updateProductEntity.PickupAddress.Line2;
                            getResult.PickupAddress.State = updateProductEntity.PickupAddress.State;
                            getResult.PickupAddress.City = updateProductEntity.PickupAddress.City;
                            getResult.PickupAddress.Pincode = updateProductEntity.PickupAddress.Pincode;
                        }
                        else
                        {
                            throw new BaseException(int.Parse(ErrorCode.InvalidPickupAddress()), Error.InvalidPickupAddress(), null, HttpStatusCode.BadRequest);
                        }
                    }
                }
                getResult.Status = updateProductEntity.Status ?? getResult.Status;
            }
            return getResult;
        }
    }
}
