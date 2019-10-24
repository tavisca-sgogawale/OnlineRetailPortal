using OnlineRetailPortal.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRetailPortal.Contracts
{
    public interface IProductService
    {
        Task<GetProductResponse> GetProductAsync(string productId);
    }
}
