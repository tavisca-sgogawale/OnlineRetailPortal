
using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRetailPortal.Mock
{
    public class MockCategoryStore : ICategoryStore
    {
        /*
         public List<Category> Categories = new List<Category>() {
             new Category(){Id = 122331, Name = "Electronics"},
             new Category(){Id = 12331, Name = "Assoseries"},
             new Category(){Id = 1331, Name = "HouseHold"},
             new Category(){Id = 11, Name = "vehicle"},
         };
         */
        public List<Category> Categories;

         public MockCategoryStore()
        {
            Categories = new List<Category>() {
             new Category(){Id = 122331, Name = "Electronics"},
             new Category(){Id = 12331, Name = "Assoseries"},
             new Category(){Id = 1331, Name = "HouseHold"},
             new Category(){Id = 11, Name = "vehicle"},
         };
        }




        public async Task<GetCategoriesStoreResponse> GetCategoriesAsync()
        {
            
            return await Task.FromResult<GetCategoriesStoreResponse>(Categories.ToCategoriesStroeResponse());
        }
    }
}
