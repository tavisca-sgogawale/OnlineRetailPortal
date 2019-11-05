using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineRetailPortal.Contracts;
using OnlineRetailPortal.Core.Object_Factory;
using OnlineRetailPortal.Mock;

namespace OnlineRetailPortal.Core
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }

        private ICategoryStore _categoryStore;
        
        public Category()
        {
            CategoryObjectFactory categoryObjectFactory = new CategoryObjectFactory();
            _categoryStore = categoryObjectFactory.GetCategoryStore();
        }

        public async Task<List<Category>> GetCategoriesAsync()
        {
            var response = await _categoryStore.GetCategoriesAsync();
            var CoreCategoriesResponse = response.ToCoreResponse();
            return CoreCategoriesResponse;
        }
    }

   
}
