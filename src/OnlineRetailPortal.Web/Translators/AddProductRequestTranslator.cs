using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineRetailPortal.Web.Translators
{
    public static class AddProductRequestTranslator
    {
        public static Contracts.AddProductRequest ToDataContract(this AddProductRequest addProductRequest)
        {
            Contracts.AddProductRequest request = new Contracts.AddProductRequest();
            request.Product.Name = addProductRequest.Name;
            return request;
        }
    }
}
