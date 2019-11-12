using System;
using System.Collections.Generic;
using System.Text;
using OnlineRetailPortal.Contracts;

namespace OnlineRetailPortal.Core
{
    public static class CategoryTranslator
    {
        public static Contracts.Category ToEntity(this Category category)
        {
            Contracts.Category contractsCategory = new Contracts.Category() { Name = category.Name };
            return contractsCategory;
        }

        public static Category ToModel(this Contracts.Category category)
        { 
            Category coreCategory = new Category(category.Name);
            return coreCategory;
        }
    }
}
