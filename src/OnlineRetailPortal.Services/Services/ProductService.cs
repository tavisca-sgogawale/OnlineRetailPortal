using OnlineRetailPortal.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineRetailPortal.Services
{
   public class ProductService : IProductService
    {
        public async Task<GetProductsServiceResponse> GetProductsAsync(GetProductsServiceRequest request)
        {
            List<Core.Product> product = Core.Product.GetProducts(request.PageNo,request.PageSize);
            return await Task.FromResult<GetProductsServiceResponse>(product.ToGetProductsContract());
        }

        public async Task<GetProductServiceResponse>  GetProductAsync(GetProductServiceRequest request)
        {
            Core.Product product = Core.Product.GetProduct(request.productId);
            return await Task.FromResult<GetProductServiceResponse>(product.ToGetProductContract());
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
