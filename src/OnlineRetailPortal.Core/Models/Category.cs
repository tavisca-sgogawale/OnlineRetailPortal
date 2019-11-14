using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRetailPortal.Core
{
    public class Category
    {
        public Category(string name)
        {
            this.Name = name;
        }

        public string Name { get; }

        public async static Task<List<Category>> GetCategoriesAsync(ICategoryStore categoryStore)
        {
            var response = await categoryStore.GetCategoriesAsync();
            var coreCategoriesResponse = response.ToCoreResponse();
            return coreCategoriesResponse;
        }



    }
}
