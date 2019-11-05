using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineRetailPortal.Contracts
{
    interface IProductStore
    {
        Task<AddProductStoreResponse> AddProductAsync(AddProductStoreRequest request);
        Task<GetProductStoreResponse> GetProductAsync(GetProductStoreRequest request);
        Task<GetProductsStoreResponse> GetProductsAsync(GetProductsStoreRequest request);
    }
}
