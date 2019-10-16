using ERPBackend.Services;
using StructureMap;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ERPBackend
{
    public class Registration : Registry
    {
        public Registration()
        {
            Scan(
                scan => {
                    scan.TheCallingAssembly();
                    scan.WithDefaultConventions();
                });

            For<IProductProvider>().Use<MockProductDatabase>();
            For<IProductService>().Use<ProductService>();
        }
    }
}
