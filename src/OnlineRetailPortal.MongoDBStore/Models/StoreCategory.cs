using System;
using System.Collections.Generic;

namespace OnlineRetailPortal.MongoDBStore
{
    public class StoreCategory
    {
        [MongoDB.Bson.Serialization.Attributes.BsonId]
        public string Name { get; set; }
        public List<string> Tags { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
