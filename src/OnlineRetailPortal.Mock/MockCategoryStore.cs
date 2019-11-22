
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
             new Category(){Name = "Accessory", Tags = new List<string>(){"Acc1","Acc2" } },
             new Category(){Name = "Bike", Tags = new List<string>(){"Bik1","Bik2" }},
             new Category(){Name = "Book", Tags = new List<string>(){"Boo1","Boo2" }},
             new Category(){Name = "Car", Tags = new List<string>(){"Car1","Car2" }},
             new Category(){Name = "Electronic", Tags = new List<string>(){"Ele1","Ele2" }},
             new Category(){Name = "Fashion", Tags = new List<string>(){"Fas1","Fas2" }},
             new Category(){Name = "Furniture", Tags = new List<string>(){"Fur1","Fur2" }},
             new Category(){Name = "Home & Kitchen", Tags = new List<string>(){"Hom1","Kit2" }},
             new Category(){Name = "Mobile", Tags = new List<string>(){"Mob","Mob2" }},
             new Category(){Name = "Property", Tags = new List<string>(){"Pro1","Pro2" }},
             new Category(){Name = "Toy", Tags = new List<string>(){"Toy1","Toy2" }},             
             new Category(){Name = "Other", Tags = new List<string>(){"Oth1","Oth2" }}            
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
