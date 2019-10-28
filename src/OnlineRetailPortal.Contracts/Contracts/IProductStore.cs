using OnlineRetailPortal.Contracts;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRetailPortal.Contracts
{
    public interface IProductStore
    {
        Task<GetProductStoreResponse> GetProductAsync(string productId);
        Task<GetProductsStoreResponse> GetProductsAsync(GetProductsStoreRequest request);
    }
}
