using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineRetailPortal.Mock
{
    public static class GetCategoriesStoreResponseTranslator
    {
        public static GetCategoriesStoreResponse ToCategoriesStoreResponse(this List<Category> categories)
        {     
            if(categories==null)
            {
                return null;
            }
            GetCategoriesStoreResponse response = new GetCategoriesStoreResponse()
            {
                Categories = categories.Select(x => new Contracts.Category()
                {
                    Name = x.Name
                }).ToList()
            };
           
            return response;
        }
    }
}