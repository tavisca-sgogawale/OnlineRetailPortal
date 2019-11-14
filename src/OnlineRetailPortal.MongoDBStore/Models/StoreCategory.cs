using System;
using System.Collections.Generic;

namespace OnlineRetailPortal.MongoDBStore
{
    public class StoreCategory
    {
        public string Name { get; set; }
        public List<string> Tags { get; set; }
        DateTime CreatedDate { get; set; }
        DateTime UpdatedDate { get; set; }
    }
}
