using OnlineRetailPortal.Contracts;
using OnlineRetailPortal.Core;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineRetailPortal.Services
{
   public class ProductService : IProductService
    {
        public async Task<GetProductsServiceResponse> GetProductsAsync(GetProductsServiceRequest request)
        {

            GetProductsCoreResponce product = await Core.Product.GetProductsAsync(request);
            return await Task.FromResult<GetProductsServiceResponse>(product.ToGetProductsContract());
        }

        public async Task<GetProductServiceResponse>  GetProductAsync(string productId)
        {
            Core.Product product = await Core.Product.GetProductAsync(productId);
            
            return product.ToGetProductContract();
        }

        public async Task<AddProductResponse> AddProductAsync(AddProductRequest addProductRequest)
        {
            //this code will be uncomminted with aditi code
            //Core.Product response = await product.AddProductAsync(addProductRequest.ToEntity());
            //return response.ToModel();
            throw new NotImplementedException();
        }
    }
}
