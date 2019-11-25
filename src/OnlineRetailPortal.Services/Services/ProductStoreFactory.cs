using Autofac.Features.Indexed;
using OnlineRetailPortal.Contracts;
using System;

namespace OnlineRetailPortal.Services
{
    public class ProductStoreFactory : IProductStoreFactory
    {
        IIndex<String, IProductStore> productStore = null;

        public ProductStoreFactory(IIndex<String, IProductStore> productStore)
        {
            this.productStore = productStore;
        }

        public IProductStore GetProductStore(string storeValue)
        {
            return this.productStore[storeValue];
        }
    }
}
