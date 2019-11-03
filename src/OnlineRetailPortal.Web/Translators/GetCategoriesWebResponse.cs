using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineRetailPortal.Web
{
    public static class ServiceResponseTranslator
    {
        public static CategoryResponse ToCategoriesContract(this Contracts.GetCategoriesServiceResponse getCategoriesServiceResponse)
        {
            CategoryResponse response = new CategoryResponse()
            {
                Categories = getCategoriesServiceResponse.Categories.Select(x => new Category()
                {
                    Id = x.Id,
                    Name = x.Name
                }).ToList()
            };
            return response;
        }
    }

}
