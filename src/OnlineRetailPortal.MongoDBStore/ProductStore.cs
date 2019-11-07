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
        private static MongoClient _dbClient = new MongoClient(DatabaseConfiguration._mongoDBConnectionString);
        private IMongoDatabase _db = _dbClient.GetDatabase(DatabaseConfiguration._databaseName);
        private string _collection = DatabaseConfiguration._productTableName;

        public async Task<AddProductStoreResponse> AddProductAsync(AddProductStoreRequest request)
        {
            var product = request.ToModel();
            product.Id = Guid.NewGuid().ToString();
            product.Status = OnlineRetailPortal.Contracts.Status.Active;
            product.PostDateTime = DateTime.Now;
            product.ExpirationDate = DateTime.Now.AddDays(30);

            var productStoreCollection = _db.GetCollection<AddProductStoreResponse>(_collection);
            try
            {
                await productStoreCollection.InsertOneAsync(product.ToEntity());
            }
            catch
            {
                throw new BaseException(int.Parse(ErrorCode.DataBaseDown()),Error.DataBaseDown(),null,HttpStatusCode.GatewayTimeout);
            }
            return product.ToEntity();
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
