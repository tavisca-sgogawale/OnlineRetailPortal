using System.Threading.Tasks;
namespace OnlineRetailPortal.Contracts
{
    public interface IProductStore
    {
        Task<ProductEntity> AddProductAsync(ProductEntity request);
        Task<ProductStoreResult> GetProductAsync(string productId);
        Task<ProductStoreResults> GetProductsAsync(SearchQuery request);
    }
}