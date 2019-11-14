using OnlineRetailPortal.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineRetailPortal.Services
{
    public static class CategoryTranslator
    {
        public static Category ToEntity(this Contracts.Category category)
        {
            Category coreCategory = new Category(category.Name);
            return coreCategory;
        }
        public static Contracts.Category ToModel(this Category category)
        {
            Contracts.Category contractsCategory = new Contracts.Category() { Name = category.Name };
            return contractsCategory;
        }


    }
}
