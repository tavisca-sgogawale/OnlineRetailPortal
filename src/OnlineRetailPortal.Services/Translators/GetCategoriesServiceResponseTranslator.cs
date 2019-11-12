using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineRetailPortal.Services
{
    public static class GetCategoriesServiceResponseTranslator
    {
        public static CategoriesServiceResponse ToCategoriesResponse(this List<Core.Category> categories)
        {
            if (categories == null)
                return null;
            CategoriesServiceResponse response = new CategoriesServiceResponse()
            {
                Categories = categories.Select(x => new Category()
                {
                    Name = x.Name
                }).ToList()
            };
            return response;
        }
    }
}
