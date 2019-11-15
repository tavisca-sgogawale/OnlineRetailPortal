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
            ICategoryStore categoryStore = CategoryObjectFactory.GetCategoryStore();
            _categoryStore = categoryStore;
        }

        public async Task<CategoriesServiceResponse> GetCategoriesAsync()
        {
            var responce = await Core.Category.GetCategoriesAsync(_categoryStore);
            return responce.ToModel();
        }
    }
}
