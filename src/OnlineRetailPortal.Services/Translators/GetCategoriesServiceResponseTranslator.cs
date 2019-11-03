using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineRetailPortal.Services
{
    public static class GetCategoriesServiceResponseTranslator
    {
        public static GetCategoriesServiceResponse ToCategoriesResponse(this List<Core.Category> categories)
        {
            GetCategoriesServiceResponse response = new GetCategoriesServiceResponse()
            {
                Categories = categories.Select(x => new Category()
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList()
            };
            return response;
        }
    }
}
