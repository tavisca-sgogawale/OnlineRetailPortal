using OnlineRetailPortal.Contracts.Models;
using OnlineRetailPortal.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRetailPortal.Contracts
{
    public interface IProductStore
    {
        Task<GetProductsResponse> GetProductsAsync(GetProductsRequest request);
        Task<Product> GetProductAsync(string productId);
    }
}
