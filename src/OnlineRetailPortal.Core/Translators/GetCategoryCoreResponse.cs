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
            var categories = new List<Category>();
            foreach(var x in getCategoriesStoreResponse.Categories)
            {
                categories.Add(new Category(x.Name) { Id = x.Id });
            }
            var response = categories;

            return response;
        }
    }
}
