using System.Threading.Tasks;
namespace OnlineRetailPortal.Contracts
{
    public interface IProductStore
    {
        Task<AddProductStoreResponse> AddProductAsync(AddProductStoreRequest request);
        Task<GetProductStoreResponse> GetProductAsync(string request);
        Task<GetProductsStoreResponse> GetProductsAsync(GetProductsEntity request);
    }
}