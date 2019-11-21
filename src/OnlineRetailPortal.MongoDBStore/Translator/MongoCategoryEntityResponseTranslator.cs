using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineRetailPortal.MongoDBStore
{
    public static class MongoCategoryEntityResponseTranslator
    {
        public static CategoriesStoreResponse ToModel(this List<StoreCategory> mongoCategoryEntity)
        {
            if (mongoCategoryEntity == null)
                return null;
            CategoriesStoreResponse getCategoryStoreResponse = new CategoriesStoreResponse()
            {
                Categories = mongoCategoryEntity.Select(x => new Category()
                {
                  Name = x.Name
                }).ToList(),
                
            };
            return getCategoryStoreResponse;
        }
    }
}
