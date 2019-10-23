using OnlineRetailPortal.Contracts;
using OnlineRetailPortal.Services.Translators;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRetailPortal.Services
{
    class ProductService : IProductService
    {
        public async Task<AddProductResponse> AddProductAsync(AddProductRequest addProductRequest)
        {
           // Core.CorePostResponse response = await AddProduct(addProductRequest.ToCore()); //function not define
           // response.ToWeb(); // not define
        }

        public Task<GetProductResponse> GetProductAsync(string productId)
        {
            throw new NotImplementedException();
        }
    }
}
