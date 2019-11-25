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
            return new Category(category?.Name);
        }
        public static Contracts.Category ToModel(this Category category)
        {
            return new Contracts.Category() { Name = category?.Name };
        }
    }
}
