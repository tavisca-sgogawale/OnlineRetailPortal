using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineRetailPortal.Mock
{
    public static class CategoriesStoreResponseTranslator
    {
        public static CategoriesStoreResponse ToEntity(this List<Category> categories)
        {     
            if(categories==null)
            {
                return null;
            }
            CategoriesStoreResponse response = new CategoriesStoreResponse()
            {
                Categories = categories.Select(x => new Contracts.Category()
                {
                    Name = x.Name,
                    Tags = x.Tags
                }).ToList()
            };
           
            return response;
        }
    }
}