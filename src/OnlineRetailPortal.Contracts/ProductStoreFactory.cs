using Autofac.Features.Indexed;
using System;

namespace OnlineRetailPortal.Contracts
{
    public class ProductStoreFactory : IProductStoreFactory
    {
        //temporary variable
        private const string _storeValue = "Mock";
        IIndex<String, IProductStore> productStore = null;

        public ProductStoreFactory(IIndex<String, IProductStore> productStore)
        {
            this.productStore = productStore;
        }

        public IProductStore GetProductStore()
        {
            return this.productStore[_storeValue];
        }
    }
}
