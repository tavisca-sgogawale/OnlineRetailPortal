using OnlineRetailPortal.Contracts;
using System.Threading.Tasks;

namespace OnlineRetailPortal.Services
{
    public class CategoryService : ICategoryService
    {
        public async Task<GetCategoriesServiceResponse> GetCategoriesAsync()
        {
            var category = new Core.Category();
            var responce = await category.GetCategoriesAsync();


            return responce.ToCategoriesResponse();


        }
    }
}
