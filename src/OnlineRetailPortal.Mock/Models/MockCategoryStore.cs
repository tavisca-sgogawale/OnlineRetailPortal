
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
             
             new Category(){Name = "Electronics"},
             new Category(){Name = "Home Appliances"},
             new Category(){Name = "Clothings"},
             new Category(){Name = "Toys"},
             new Category(){Name = "Books"},
         };
        }

        public async Task<GetCategoriesStoreResponse> GetCategoriesAsync()
        {
            if(Categories==null)
            {
                return null;
            }
            return await Task.FromResult<GetCategoriesStoreResponse>(Categories.ToCategoriesStoreResponse());
        }
    }
}
