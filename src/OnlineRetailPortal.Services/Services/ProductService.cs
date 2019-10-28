using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRetailPortal.Services
{
    class ProductService : IProductService
    {
       
        public Task<GetProductsServiceResponse> GetProductsAsync(GetProductsServiceRequest request)
        {
            throw new NotImplementedException();
        }

        public Task<GetProductServiceResponse> GetProductAsync(string productId)
        {
            throw new NotImplementedException();
        }
    }
}
