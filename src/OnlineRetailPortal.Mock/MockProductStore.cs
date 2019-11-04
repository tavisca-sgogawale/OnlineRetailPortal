using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRetailPortal.Mock
{
    public class MockProductStore : IProductStore
    {
        public Task<GetProductStoreResponse> GetProductAsync(string productId)
        {
            throw new NotImplementedException();
        }

        public Task<GetProductsStoreResponse> GetProductsAsync(GetProductsStoreRequest request)
        {
            throw new NotImplementedException();
        }
    }
}
