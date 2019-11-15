using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineRetailPortal.Mock
{
    public class CategoryStoreFactory : ICategoryStoreFactory
    {
        public ICategoryStore GetCategoryStore()
        {
            //if (typeOfCategoryStore == "Mock")
            return new MockCategoryStore();
            //else
            // implementation for DB

        }
    }
}
