using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Resources;

namespace OnlineRetailPortal.Web.Translators
{
    public static class AddProductResponseTranslator
    {
        public static AddProductResponse ToUser(this Contracts.AddProductResponse addProductResponse)
        {
            AddProductResponse response = new AddProductResponse();
            response.Name = addProductResponse.Product.Name;
            return response;
        }
    }
}
