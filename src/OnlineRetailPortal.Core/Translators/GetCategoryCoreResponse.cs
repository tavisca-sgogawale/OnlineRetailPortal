using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;

namespace OnlineRetailPortal.Core

{
    public static class GetCategoryCoreResponse
    {
        public static List<Category> ToCoreResponse(this Contracts.GetCategoriesStoreResponse getCategoriesStoreResponse)
        {
            var response = getCategoriesStoreResponse.Categories.Select(x => new Category()
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();

            return response;
        }
    }
}
