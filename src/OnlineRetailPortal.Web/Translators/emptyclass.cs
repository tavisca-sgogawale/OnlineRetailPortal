using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineRetailPortal.Web
{
    public static class ResponseTranslator
    {
        public static GetProductResponse ToDataContract(this Contracts.GetProductResponse getProductResponse)
        {
            GetProductResponse response = new GetProductResponse();
            response.Name = getProductResponse.Product.Name;
            return response;
        }
    }
}
