using MongoDB.Bson;
using System;
using System.Collections.Generic;

namespace OnlineRetailPortal.MongoDBStore
{
    public class StoreCategory
    {
        public ObjectId Id { get; set; }
        public string Name { get; set; }
        public List<string> Tags { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
