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


        public async Task<GetProductStoreResponse> GetProductAsync(string productId)
        {
            //ProductEntity product;
            //try
            //{
            //    var productStoreCollection = _db.GetCollection<ProductEntity>(_collection);
            //    var filter = Builders<ProductEntity>.Filter.Eq("Id", productId);
            //    product =  await productStoreCollection.FindAsync(filter);
            //}
            //catch
            //{
            //    throw new BaseException(int.Parse(ErrorCode.DataBaseDown()), Error.DataBaseDown(), null, HttpStatusCode.GatewayTimeout);
            //}
            //return product;
            throw new NotImplementedException();
        }

        public async Task<GetProductsStoreResponse> GetProductsAsync(GetProductsEntity request)
        {
            var data = _db.GetCollection<Contracts.Product>(_collection);
            List<Contracts.Product> products = (await data.FindAsync(new BsonDocument())).ToList();
            return new GetProductsStoreResponse() { Products = products };
        }
    }
}
