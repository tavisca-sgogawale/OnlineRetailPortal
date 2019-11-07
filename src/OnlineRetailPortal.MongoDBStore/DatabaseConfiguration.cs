using MongoDB.Driver;
using System;

namespace OnlineRetailPortal.MongoDBStore
{
    public static class DatabaseConfiguration
    {
        public static readonly string _mongoDBConnectionString = "mongodb://127.0.0.1:27017";
        public static readonly string _databaseName = "ORP";
        public static readonly string _productTableName = "Product";
        public static MongoClientSettings _mongoSettings = new MongoClientSettings
        {
            Server = new MongoServerAddress(DatabaseConfiguration._mongoDBConnectionString),
            SocketTimeout = new TimeSpan(0, 0, 0, 2),
            WaitQueueTimeout = new TimeSpan(0, 0, 0, 2),
            ConnectTimeout = new TimeSpan(0, 0, 0, 2)
        };
}
}
