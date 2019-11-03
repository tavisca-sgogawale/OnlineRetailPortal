using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineRetailPortal.Mock
{
    public static class GetCategoriesStoreResponseTranslator
    {
        public static GetCategoriesStoreResponse ToCategoriesStroeResponse(this List<Category> categories)
        {
            GetCategoriesStoreResponse response = new GetCategoriesStoreResponse()
            {
                Categories = categories.Select(x => new Contracts.Category()
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList()
            };
            return response;
        }
    }
}
