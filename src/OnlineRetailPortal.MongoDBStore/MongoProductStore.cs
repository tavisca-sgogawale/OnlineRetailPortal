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
            MongoEntity getResult;
            var productStoreCollection = _db.GetCollection<MongoEntity>(_collection);
            getResult = await productStoreCollection.Find(x => x.Id == productEntity.Id).FirstOrDefaultAsync();
            getResult = UpdateProductEntity(await productStoreCollection.Find(x => x.Id == productEntity.Id).FirstOrDefaultAsync(), productEntity);
            var filter = Builders<MongoEntity>.Filter.Eq("Id", productEntity.Id);
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
        private bool ValidatePickupAddress(MongoEntity productEntity)
        {
            if(productEntity.PickupAddress.Line1 != null && productEntity.PickupAddress.City != null && productEntity.PickupAddress.State != null && productEntity.PickupAddress.Pincode > 0)
            {
                return true;
            }
            return false;
        }
        private bool ValidatePickupAddress(ProductEntity productEntity)
        {
            if (productEntity.PickupAddress.Line1 != null && productEntity.PickupAddress.City != null && productEntity.PickupAddress.State != null && productEntity.PickupAddress.Pincode > 0)
            {
                return true;
            }
            return false;
        }
        private MongoEntity UpdateProductEntity(MongoEntity getResult, ProductEntity productEntity)
        {
            if (getResult != null)
            {
                getResult.Name = productEntity.Name ?? getResult.Name;
                getResult.Description = productEntity.Description ?? getResult.Description;
                getResult.Category = productEntity.Category.Name ?? getResult.Category;



                getResult.Gallery.ImageUrls = (productEntity.Images != null) ?
                                                    productEntity.Images : getResult.Gallery.ImageUrls;
                getResult.Price.Amount = (productEntity.Price != null) ?
                                                 (productEntity.Price.Money != null) ?
                                                        productEntity.Price.Money.Amount : getResult.Price.Amount
                                          : getResult.Price.Amount;
                getResult.Price.IsNegotiable = (productEntity.Price != null) ?
                                                    (productEntity.Price.IsNegotiable != null) ?
                                                            Convert.ToBoolean(productEntity.Price.IsNegotiable) : getResult.Price.IsNegotiable
                                                : getResult.Price.IsNegotiable;
                getResult.Gallery.HeroImageUrl = (productEntity.HeroImage != null) ?
                                                        productEntity.HeroImage : getResult.Gallery.HeroImageUrl;
                getResult.PurchasedDate = productEntity.PurchasedDate ?? getResult.PurchasedDate;

                if (productEntity.PickupAddress != null)
                {
                    if(ValidatePickupAddress(getResult))
                    {
                        getResult.PickupAddress.Line1 = productEntity.PickupAddress.Line1 ?? getResult.PickupAddress.Line1;
                        getResult.PickupAddress.Line2 = productEntity.PickupAddress.Line2 ?? getResult.PickupAddress.Line2;
                        getResult.PickupAddress.State = productEntity.PickupAddress.State ?? getResult.PickupAddress.State;
                        getResult.PickupAddress.City = productEntity.PickupAddress.City ?? getResult.PickupAddress.City;
                        getResult.PickupAddress.Pincode = (productEntity.PickupAddress.Pincode != 0) ?
                                                                productEntity.PickupAddress.Pincode : getResult.PickupAddress.Pincode;
                    }
                    else
                    {
                        if (ValidatePickupAddress(productEntity))
                        {
                            getResult.PickupAddress.Line1 = productEntity.PickupAddress.Line1;
                            getResult.PickupAddress.Line2 = productEntity.PickupAddress.Line2;
                            getResult.PickupAddress.State = productEntity.PickupAddress.State;
                            getResult.PickupAddress.City = productEntity.PickupAddress.City;
                            getResult.PickupAddress.Pincode = productEntity.PickupAddress.Pincode;
                        }
                        else
                        {
                            throw new BaseException(int.Parse(ErrorCode.InvalidPickupAddress()), Error.InvalidPickupAddress(), null, HttpStatusCode.BadRequest);
                        }
                    }
                }
                getResult.Status = productEntity.Status.ToString() ?? getResult.Status;
            }
            return getResult;
        }
    }
}
