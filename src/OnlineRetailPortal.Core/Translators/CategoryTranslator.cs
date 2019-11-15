using System;

namespace OnlineRetailPortal.Core
{
    public static class CategoryTranslator
    {
        public static Contracts.Category ToEntity(this Category category)
        {
            return new Contracts.Category() { Name = category?.Name };
        }

        public static Category ToModel(this Contracts.Category category)
        {
            return new Category(category?.Name);
        }
    }
}
