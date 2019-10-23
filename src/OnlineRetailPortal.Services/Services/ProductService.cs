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
        public Task<AddProductResponse> AddProductAsync(AddProductRequest addProductRequest)
        {
            //var response = AddProduct(addProductRequest.ToCore()); //function not define
            //response.ToWeb(); // not define
        }

        public Task<GetProductResponse> GetProductAsync(string productId)
        {
            throw new NotImplementedException();
        }
    }
}
