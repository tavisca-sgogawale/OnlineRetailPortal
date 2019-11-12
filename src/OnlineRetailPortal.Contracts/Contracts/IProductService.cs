using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRetailPortal.Contracts
{
    public interface IProductService
    {
        Task<AddProductResponse> AddProductAsync(AddProductRequest addProductRequest);
        Task<GetProductServiceResponse> GetProductAsync(string productId);
        Task<GetProductsServiceResponse> GetProductsAsync(GetProductsServiceRequest request);
        Task<UpdateProductEntity> UpdateProductAsync(UpdateProductEntity updateProductEntity);
    }

}
