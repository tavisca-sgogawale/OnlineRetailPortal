using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRetailPortal.Core
{
    public class CoreService
    {
        IProductStore productStore;

        public CoreService(IProductStore productStore)
        {
            
            this.productStore = productStore;
        }

        public async Task<CorePostResponse> AddProduct(CorePostRequest product)
        {
            EntityPostRequest entityPostRequest = product.ToEntityRequest();
            
            EntityPostResponse entityPostResponse = await productStore.PostProductAsync(entityPostRequest);
            
            CorePostResponse responseProduct = entityPostResponse.ToProduct();

            return responseProduct;
        }
    }
}
