using OnlineRetailPortal.Contracts;
using System.Threading.Tasks;

namespace OnlineRetailPortal.MongoDBStore
{
    public class ProductStore : IProductStore
    {
        public Task<AddProductStoreResponse> AddProductAsync(AddProductStoreRequest request)
        {
            throw new System.NotImplementedException();
        }

        public Task<GetProductStoreResponse> GetProductAsync(GetProductStoreRequest request)
        {
            throw new System.NotImplementedException();
        }

        public Task<GetProductsStoreResponse> GetProductsAsync(GetProductsStoreRequest request)
        {
            throw new System.NotImplementedException();
        }
    }
}
