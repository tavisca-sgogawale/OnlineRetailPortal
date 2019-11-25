using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineRetailPortal.Web
{
    public static class CategoryTranslator
    {
        public static Contracts.Category ToEntity(this string category)
        {
            Contracts.Category contractsCategory = new Contracts.Category() 
            { 
                Name = category 
            };
            return contractsCategory;
        }

        public static string ToModel(this Contracts.Category category)
        {
            return category?.Name;
        }
    }
}
