using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineRetailPortal.MongoDBStore
{
    class MongoCategoryStore
    {
        private static MongoClient _dbClient = new MongoClient(new MongoClientSettings
        {
            Server = new MongoServerAddress(MongoDBConfiguration.Url, int.Parse(MongoDBConfiguration.Port)),
            SocketTimeout = new TimeSpan(0, 0, 0, 10),
            WaitQueueTimeout = new TimeSpan(0, 0, 0, 2),
            ConnectTimeout = new TimeSpan(0, 0, 0, 10)
        });

        private IMongoDatabase _db = _dbClient.GetDatabase(MongoDBConfiguration.Database);


    }
}
