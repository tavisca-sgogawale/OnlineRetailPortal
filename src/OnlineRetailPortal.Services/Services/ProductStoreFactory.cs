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

        public IProductStore GetProductStore()
        {
            return (Contracts.Environment.isMockingEnabled) ? this.productStore["Mock"] : this.productStore["Mongo"];
        }
    }
}
