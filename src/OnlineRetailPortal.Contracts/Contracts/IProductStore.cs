using System.Threading.Tasks;
namespace OnlineRetailPortal.Contracts
{
    public interface IProductStore
    {
        Task<ProductEntity> AddProductAsync(ProductEntity request);
        Task<GetProductStoreResponse> GetProductAsync(string productId);
        Task<GetProductsStoreResponse> GetProductsAsync(GetProductsStoreEntity request);
        Task<ProductEntity> UpdateProductAsync(UpdateProductEntity request);
    }
}