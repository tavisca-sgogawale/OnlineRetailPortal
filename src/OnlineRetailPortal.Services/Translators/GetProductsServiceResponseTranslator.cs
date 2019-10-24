using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OnlineRetailPortal.Services
{
    static class GetProductsServiceResponseTranslator
    {

        public static GetProductsServiceResponse ToGetProductsContract(this List<Core.Product> getProductsResponse)
        {
            GetProductsServiceResponse response = new GetProductsServiceResponse();
            return response;
           
        }

    }
}
