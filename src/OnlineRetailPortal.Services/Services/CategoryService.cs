using OnlineRetailPortal.Contracts;
using OnlineRetailPortal.Core;
using System.Threading.Tasks;

namespace OnlineRetailPortal.Services
{
    public class CategoryService : ICategoryService
    {
        private ICategoryStore _categoryStore;
        public CategoryService(ICategoryStore categoryStore)//CategoryObjectFactory objectFactory)
        {

              //ICategoryStore categoryStore = objectFactory.GetCategoryStore();
            _categoryStore = categoryStore;


        }
        public async Task<GetCategoriesServiceResponse> GetCategoriesAsync()
        {
            var category = new Core.Category();



            var responce = await category.GetCategoriesAsync(_categoryStore);

            return responce.ToCategoriesResponse();
        }
    }
}
