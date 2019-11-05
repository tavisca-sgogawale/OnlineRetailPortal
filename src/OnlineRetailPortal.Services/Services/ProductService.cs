using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using OnlineRetailPortal.Mock;

namespace OnlineRetailPortal.Services
{
    public class ProductService : IProductService
    {
        IProductStoreFactory productStoreFactory;
        IProductStore productStore ;
        Core.Product product;

        public ProductService()
        {
            this.productStoreFactory = new ProductStoreFactory();
            this.productStore = productStoreFactory.GetProductStore("Mock");
            product = new Core.Product(this.productStore);
        }

        public async Task<AddProductResponse> AddProductAsync(AddProductRequest addProductRequest)
        {
            Core.Product response = await product.AddProductAsync(addProductRequest.ToEntity());
            return response.ToModel();
        }
    }
}
