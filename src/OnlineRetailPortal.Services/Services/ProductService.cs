using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRetailPortal.Services
{
    class ProductService : IProductService
    {
        public Task<AddProductResponse> AddProductAsync(AddProductRequest addProductRequest)
        {
            throw new NotImplementedException();
        }

        public Task<GetProductResponse> GetProductAsync(string productId)
        {
            throw new NotImplementedException();
        }
    }
}
