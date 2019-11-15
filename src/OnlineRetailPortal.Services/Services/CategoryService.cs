using OnlineRetailPortal.Contracts;
using OnlineRetailPortal.Core;
using System.Threading.Tasks;

namespace OnlineRetailPortal.Services
{
    public class CategoryService : ICategoryService
    {
        private ICategoryStore _categoryStore;
        public CategoryService(ICategoryStoreFactory CategoryObjectFactory)
        {
            _categoryStore = CategoryObjectFactory.GetCategoryStore();
        }

        public async Task<CategoriesServiceResponse> GetCategoriesAsync()
        {
            var response = await Core.Category.GetCategoriesAsync(_categoryStore);
            return response.ToModel();
        }
    }
}
