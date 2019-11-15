using System;
using System.Collections.Generic;
using System.Linq;

using System.Text;

namespace OnlineRetailPortal.Core

{
    public static class GetCategoryCoreResponseTranslator
    {
        public static List<Category> ToEntity(this Contracts.GetCategoriesStoreResponse getCategoriesStoreResponse)
        {
            if (getCategoriesStoreResponse == null)
                return null;
            var categories = new List<Category>();
            foreach(var x in getCategoriesStoreResponse.Categories)
            {
                categories.Add(new Category(x.Name));
            }
            var response = categories;

            return response;
        }
    }
}
