using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineRetailPortal.Web
{
    public static class CategoryResponseTranslator
    {
        public static CategoryResponse ToEntity(this Contracts.CategoriesServiceResponse getCategoriesServiceResponse)
        {
            /*
            CategoryResponse response = new CategoryResponse() { 
                Categories = getCategoriesServiceResponse.Categories.Select(x => new Category()
                {
                    Name = x.Name,
                    Tags = x.Tags
                }).ToList(),
            };
            */
            CategoryResponse response = new CategoryResponse();
            if (getCategoriesServiceResponse?.Categories == null)
            {
                response.Categories = new List<Category>() { };
            }

            response.Categories = getCategoriesServiceResponse.Categories.Select(x => new Category()
            {
                Name = x.Name,
                Tags = x.Tags
            }).ToList();
            
            return response;
        }
    }

}
