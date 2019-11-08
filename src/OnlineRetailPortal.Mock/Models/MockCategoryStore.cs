
using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRetailPortal.Mock
{
    public class MockCategoryStore : ICategoryStore
    {
        
        public List<Category> Categories;

         public MockCategoryStore()
        {
            Categories = new List<Category>() {
             new Category(){Id = 631273, Name = "Electronics"},
             new Category(){Id = 78237, Name = "Home Appliances"},
             new Category(){Id = 62873, Name = "Clothings"},
             new Category(){Id = 531273, Name = "Toys"},
             new Category(){Id = 6482731, Name = "Books"},
         };
        }

        public async Task<GetCategoriesStoreResponse> GetCategoriesAsync()
        {
            
            return await Task.FromResult<GetCategoriesStoreResponse>(Categories.ToCategoriesStoreResponse());
        }
    }
}
