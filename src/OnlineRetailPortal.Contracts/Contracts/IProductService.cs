using OnlineRetailPortal.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRetailPortal.Contracts
{
    public interface IProductService
    {
        Task<GetProductServiceResponse> GetProductAsync(string productId);
        Task<GetProductsServiceResponse> GetProductsAsync(GetProductsServiceRequest request);
        Task<AddProductResponse> AddProductAsync(AddProductRequest addProductRequest);
    }

}
