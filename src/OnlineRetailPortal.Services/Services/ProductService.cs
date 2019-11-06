using OnlineRetailPortal.Contracts;
using OnlineRetailPortal.Mock;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRetailPortal.Services
{
    public class ProductService : IProductService
    {
        IProductStore productStore;
        IProductStoreFactory storeFactory;

        public ProductService()
        {
            this.storeFactory = new ProductStoreFactory();
            productStore = storeFactory.GetProductStore("Mock");
        }

        public async Task<AddProductResponse> AddProductAsync(AddProductRequest addProductRequest)
        {
            Core.Product product = new Core.Product(productStore,addProductRequest.SellerId,addProductRequest.Name,addProductRequest.Price.ToEntity());
            product = addProductRequest.ToEntity(productStore);
            Core.Product response = await product.AddProductAsync(product);
            return response.ToModel();
        }

    }
}
