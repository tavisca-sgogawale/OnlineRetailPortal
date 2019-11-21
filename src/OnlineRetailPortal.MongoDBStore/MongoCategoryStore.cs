using MongoDB.Bson;
using MongoDB.Driver;
using OnlineRetailPortal.Contracts;
using OnlineRetailPortal.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRetailPortal.MongoDBStore
{
   public class MongoCategoryStore : ICategoryStore 
    {
        private static MongoClient _dbClient = new MongoClient(new MongoClientSettings
        {
            Server = new MongoServerAddress(MongoDBConfiguration.Url, int.Parse(MongoDBConfiguration.Port)),
            SocketTimeout = new TimeSpan(0, 0, 0, 10),
            WaitQueueTimeout = new TimeSpan(0, 0, 0, 2),
            ConnectTimeout = new TimeSpan(0, 0, 0, 10)
        });

        private IMongoDatabase _db = _dbClient.GetDatabase(MongoDBConfiguration.Database);
        private string _collection = MongoDBConfiguration.CategoryCollection;

        public async Task<CategoriesStoreResponse> GetCategoriesAsync()
        {
            List<StoreCategory> mongoCategoriesEntities;
            try
            {
                var data = _db.GetCollection<StoreCategory>(_collection);
                mongoCategoriesEntities = await data.Find(new BsonDocument()).ToListAsync();
            }
            catch(Exception ex)
            {
                throw new BaseException(int.Parse(ErrorCode.DataBaseDown()), Error.DataBaseDown(), null, System.Net.HttpStatusCode.GatewayTimeout);
            }
            return mongoCategoriesEntities.ToModel();
        }
    }
}
