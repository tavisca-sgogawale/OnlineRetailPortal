using OnlineRetailPortal.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRetailPortal.Contracts
{
    interface IProductService
    {
        Task<AddProductResponse> AddProductAsync(AddProductRequest addProductRequest);
        Task<GetProductServiceResponse> GetProductAsync(string productId);
        Task<GetProductsServiceResponse> GetProductsAsync(GetProductsServiceRequest request);
    }

}
