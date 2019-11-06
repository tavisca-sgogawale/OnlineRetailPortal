using System.Threading.Tasks;
namespace OnlineRetailPortal.Contracts
{
    public interface IProductStore
    {
        Task<AddProductStoreResponse> AddProductAsync(AddProductStoreRequest request);
        Task<GetProductStoreResponse> GetProductAsync(GetProductStoreRequest request);
        Task<GetProductsStoreResponse> GetProductsAsync(GetProductsStoreRequest request);
    }
}