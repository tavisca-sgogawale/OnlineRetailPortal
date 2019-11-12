using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineRetailPortal.Web
{
    public static class ServiceResponseTranslator
    {
        public static CategoryResponse ToCategoriesContract(this Contracts.CategoriesServiceResponse getCategoriesServiceResponse)
        {
            
            if (getCategoriesServiceResponse == null)
                return null;
            CategoryResponse response = new CategoryResponse()
            {
                Categories = getCategoriesServiceResponse.Categories.Select(x => new Category()
                {
                    Name = x.Name
                }).ToList()
            };
            return response;
        }
    }

}
