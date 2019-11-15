
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
             new Category(){Name = "Assoseries"},
             new Category(){Name = "Bikes"},
             new Category(){Name = "Books"},
             new Category(){Name = "Cars"},
             new Category(){Name = "Electronics"},
             new Category(){Name = "Fashions"},
             new Category(){Name = "Furnitures"},
             new Category(){Name = "Home & Kitchens"},
             new Category(){Name = "Mobiles"},
             new Category(){Name = "Properties"},
             new Category(){Name = "Toys"},             
             new Category(){Name = "Others"}            
         };
        }

        public async Task<GetCategoriesStoreResponse> GetCategoriesAsync()
        {
            if(Categories==null)
            {
                return null;
            }
            return await Task.FromResult<GetCategoriesStoreResponse>(Categories.ToEntity());
        }
    }
}
