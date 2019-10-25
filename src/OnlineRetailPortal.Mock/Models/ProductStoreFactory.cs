using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineRetailPortal.Mock.Models
{
    class ProductStoreFactory : IProductStoreFactory
    {
        public IProductStore GetProductStore(string storeValue)
        {
            if(storeValue == "Mock")
            { 
                    return new MockProductStore();
            }
            IServiceProvider serviceProvider = null;
            return serviceProvider.GetService(typeof(IProductStore)) as IProductStore;
        }
    }
}
