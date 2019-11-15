using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineRetailPortal.MongoDBStore
{
    public static class CategoryTranslator
    {
        public static string ToEntity(this Category category)
        {
            return category.Name;
        }

        public static Category ToModel(this string category)
        {
            Category res = new Category() { Name = category };
            return res;
        }
    }
}
