using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineRetailPortal.Services
{
    public static class CategoriesServiceResponseTranslator
    {
       public static CategoriesServiceResponse ToModel(this List<Core.Category> categories)
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
