using MongoDB.Driver;
using System;

namespace OnlineRetailPortal.MongoDBStore
{
    public static class DatabaseConfiguration
    {
        public static readonly string _mongoDBConnectionUrl = "mongodb://127.0.0.1";
        public static readonly string _databaseName = "ORP";
        public static readonly string _productTableName = "Product";
        public static readonly int _mongoDBConnectionPort = 27017;
        public static MongoClientSettings _mongoSettings = new MongoClientSettings
        {
            Server = new MongoServerAddress(DatabaseConfiguration._mongoDBConnectionUrl,_mongoDBConnectionPort),
            SocketTimeout = new TimeSpan(0, 0, 0, 2),
            WaitQueueTimeout = new TimeSpan(0, 0, 0, 2),
            ConnectTimeout = new TimeSpan(0, 0, 0, 2)
        };
}
}
