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

            var sortDefinition = (orderBy.ToLowerInvariant() == "asc") ?
                                 (Builders<MongoEntity>.Sort.Ascending(sortType)) :
                                 (Builders<MongoEntity>.Sort.Descending(sortType));

            try
            {
                if (request.Filters.Count > 0)
                {
                    FilterDefinition<MongoEntity> filters = FilterDefinition<MongoEntity>.Empty;
                    var builder = Builders<MongoEntity>.Filter;
                    foreach (var filter in request.Filters)
                    {
                        if (filter.GetType().Name == "PriceFilter")
                        {
                            PriceFilter price = filter as PriceFilter;
                            filters = filters & builder.Gt("Price.Amount", price.Min) & builder.Lte("Price.Amount", price.Max);
                        }
                        else if (filter.GetType().Name == "SearchFilter")
                        {
                            SearchFilter search = filter as SearchFilter;
                            filters = filters & builder.Text(search.SearchQuery);
                        }
                        else if (filter.GetType().Name == "IdFilter")
                        {
                            IdFilter id = filter as IdFilter;
                            filters = filters & builder.Eq("SellerId", id.SellerId);
                        }
                        else if (filter.GetType().Name == "StatusFilter")
                        {
                            StatusFilter status = filter as StatusFilter;
                            filters = filters & builder.Eq("Status", status.Status);
                        }
                    }
                    var docCount = (int)await collection.Find(filters).CountDocumentsAsync();
                    request.PagingInfo.TotalPages = (docCount >= pageSize) ?
                                                    ((docCount / pageSize) + ((docCount % pageSize) == 0 ? 0 : 1)) : 1;
                    mongoEntities = await collection.Find(filters)
                                                    .Skip(skipDocuments)
                                                    .Limit(pageSize)
                                                    .Sort(sortDefinition)
                                                    .ToListAsync();


                }
                else
                {
                    var docCount = (int)await collection.CountDocumentsAsync(new BsonDocument());

                    request.PagingInfo.TotalPages = (docCount >= pageSize) ?
                                                    ((docCount / pageSize) + ((docCount % pageSize) == 0 ? 0 : 1)) : 1;

                    var skipDocumentEnabled = (pageNumber - 1 * pageSize) > docCount ? false : true;

                    if (skipDocumentEnabled)
                    {
                        FilterDefinition<MongoEntity> filters = FilterDefinition<MongoEntity>.Empty;
                        var builder = Builders<MongoEntity>.Filter;
                        filters = builder.Eq("Status", "Active");
                        mongoEntities = await collection.Find(filters)
                                                    .Skip(skipDocuments)
                                                    .Limit(pageSize)
                                                    .Sort(sortDefinition)
                                                    .ToListAsync();
                    }
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
    }
}
