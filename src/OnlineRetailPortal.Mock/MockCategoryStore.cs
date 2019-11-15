
using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRetailPortal.Mock
{
    public class MockCategoryStore : ICategoryStore
    {
        private List<Category> Categories;
         public MockCategoryStore()
        {
            Categories = new List<Category>() {             
             new Category(){Name = "Accessory"},
             new Category(){Name = "Bike"},
             new Category(){Name = "Book"},
             new Category(){Name = "Car"},
             new Category(){Name = "Electronic"},
             new Category(){Name = "Fashion"},
             new Category(){Name = "Furniture"},
             new Category(){Name = "Home & Kitchen"},
             new Category(){Name = "Mobile"},
             new Category(){Name = "Property"},
             new Category(){Name = "Toy"},             
             new Category(){Name = "Other"}            
         };
        }

        public async Task<CategoriesStoreResponse> GetCategoriesAsync()
        {
            if(Categories==null)
            {
                return null;
            }
            return await Task.FromResult<CategoriesStoreResponse>(Categories.ToEntity());
        }
    }
}
