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
            IProductStore productStore=null;
            var response = await Core.Product.GetProductsAsync(request,productStore );
            //get list based on paging info 
            return await Task.FromResult(response.ToGetProductsContract());
        }

        public async Task<GetProductServiceResponse>  GetProductAsync(string productId)
        {
            IProductStore productStore = null;
           var response = await Core.Product.GetProductAsync(productId, productStore);
            return response.ToGetProductContract();
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
