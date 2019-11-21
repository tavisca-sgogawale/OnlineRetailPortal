using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using OnlineRetailPortal;
using OnlineRetailPortal.MongoDBStore;


namespace OnlineRetailPortal.Mock
{
    public class CategoryStoreFactory : ICategoryStoreFactory
    {
        private const string _storeValue = "DB";
        public ICategoryStore GetCategoryStore()
        {
            //current implementation for mock,will add DB implementation later  
            if (_storeValue == "Mock")
                return new MockCategoryStore();
            else
                return new MongoCategoryStore();
        }
    }
}
