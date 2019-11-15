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
            CategoryResponse response = new CategoryResponse() { Categories = new List<string>() { } };
            
            if (getCategoriesServiceResponse == null)
            {
                return response;
            }         
            response.Categories = getCategoriesServiceResponse.Categories.Select(x => x.Name).ToList();
            return response;
        }
    }

}
