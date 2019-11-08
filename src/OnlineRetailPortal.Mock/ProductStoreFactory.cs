using OnlineRetailPortal.Contracts;
using OnlineRetailPortal.MongoDBStore;
using System;

namespace OnlineRetailPortal.Mock
{
    public class ProductStoreFactory : IProductStoreFactory
    {
        public IProductStore GetProductStore(string storeValue)
        {
            //returns mock object for this  string
            if (storeValue == "Mock")
            {
                return new MockProductStore();
            }
            else if (storeValue == "Mongo")
            {
                return new MongoProductStore();
            }

            //To get service object
            IServiceProvider serviceProvider = null;

            // returns service object of the specified type by mapping using DI
            return serviceProvider.GetService(typeof(IProductStore)) as IProductStore;
        }
    }
}
