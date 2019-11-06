using OnlineRetailPortal.Contracts;
using OnlineRetailPortal.Mock;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineRetailPortal.Core
{
    public class CategoryObjectFactory:ICategoryStoreFactory 
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
