using OnlineRetailPortal.Contracts;
using OnlineRetailPortal.Core;
using OnlineRetailPortal.Services.Translators;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OnlineRetailPortal.Mock.Models;

namespace OnlineRetailPortal.Services
{
    class ProductService : IProductService
    {
        IProductStoreFactory productStoreFactory;
        IProductStore productStore;
        Core.Product product;

        public ProductService()
        {
            //     this.productStore = productStoreFactory.GetStoreType("Mock");
            product = new Core.Product(this.productStore);
        }

        public async Task<AddProductResponse> AddProductAsync(AddProductRequest addProductRequest)
        {
            Core.Product response = await product.AddProductAsync(addProductRequest.ToCore());
            return response.ToWeb();
        }
    }
}
