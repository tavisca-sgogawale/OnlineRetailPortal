using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRetailPortal.Core
{
    public class Category
    {
        public string Name { get; }
        
        public Category(string name)
        {
            this.Name = name;
        }
        public async static Task<List<Category>> GetCategoriesAsync(ICategoryStore categoryStore)
        {
            var response = await categoryStore.GetCategoriesAsync();
            var coreCategoriesResponse = response.ToEntity();
            return coreCategoriesResponse;
        }
    }
}
