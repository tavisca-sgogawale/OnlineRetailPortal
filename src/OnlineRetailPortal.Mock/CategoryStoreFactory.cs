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
            //current implementation for mock,will add DB implementation later  
            return new MockCategoryStore();
        }
    }
}
