using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineRetailPortal.Mock
{
    public static class GetProductStoreResponseTranslator
    {
        public static GetProductStoreResponse ToGetProductStore(this Product product)
        {
            GetProductStoreResponse response = new GetProductStoreResponse()
            {
                Product = product
            };
            return response;

        }
    }
}
