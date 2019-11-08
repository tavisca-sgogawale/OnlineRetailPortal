using OnlineRetailPortal.Contracts;
using OnlineRetailPortal.MongoDBStore;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineRetailPortal.Mock
{
    public class ProductStoreFactory : IProductStoreFactory
    {
        //temporary variable
        private const string _storeValue = "Mongo";
        public IProductStore GetProductStore()
        {
            //returns mock object for this  string
            if (_storeValue == "Mock")
            {
                return new MockProductStore();
            }
            else if (_storeValue == "Mongo")
            {
                return new MongoProductStore();
            }
            //To be implemented in future

            //To get service object
            //IServiceProvider serviceProvider = null;

            //// returns service object of the specified type by mapping using DI
            //return serviceProvider.GetService(typeof(IProductStore)) as IProductStore;
        }
    }
}
