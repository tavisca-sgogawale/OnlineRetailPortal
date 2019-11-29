using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Autofac;
using OnlineRetailPortal.Contracts;
using OnlineRetailPortal.Mock;
using OnlineRetailPortal.MongoDBStore;
using OnlineRetailPortal.Services;
using OnlineRetailPortal.Services.Services;

namespace OnlineRetailPortal.Web
{
    public class ServiceRegistry : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductService>().As<IProductService>();
            builder.RegisterType<ProductStoreFactory>().As<IProductStoreFactory>();
            builder.RegisterType<ImageService>().As<IImageService>();
            builder.RegisterType<CategoryStoreFactory>().As<ICategoryStoreFactory>();
            builder.RegisterType<CategoryService>().As<ICategoryService>();
            builder.RegisterType<MockProductStore>().Keyed<IProductStore>("Mock");
            builder.RegisterType<MongoProductStore>().Keyed<IProductStore>("Mongo");
        }
    }
}
