using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineRetailPortal.Contracts;
using OnlineRetailPortal.Mock;

namespace OnlineRetailPortal.Core
{
    public class Category
    {
        public Category(string name)
        {
            this.Name = name;
        }
        public int Id { get; set; }
        public string Name { get; }

        //private ICategoryStore _categoryStore;
        
        //public Category()
        //{
        //    CategoryObjectFactory categoryObjectFactory = new CategoryObjectFactory();
        //  ICategoryStore _categoryStore = categoryObjectFactory.GetCategoryStore();
        //}

        public async static Task<List<Category>> GetCategoriesAsync(ICategoryStore categoryStore)
        {
            var response = await categoryStore.GetCategoriesAsync();
            var CoreCategoriesResponse = response.ToCoreResponse();
            return CoreCategoriesResponse;
        }


        
    }

   
}
