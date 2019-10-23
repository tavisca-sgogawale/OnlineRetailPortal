using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRetailPortal.Core
{
    public class CoreService
    {
        IProductStoreFactory storeFactory;
        IProductStore productStore;

        public CoreService(IProductStore productStore)
        {
            
            this.productStore = productStore;
        }

        public async Task<CorePostResponse> AddProduct(CorePostRequest product)
        {
            //translate product to request
            EntityPostRequest entityPostRequest = product.ToEntityRequest();
            //call product store method
            EntityPostResponse entityPostResponse = await productStore.PostProductAsync(entityPostRequest);
            //translate response back to product
            CorePostResponse responseProduct = entityPostResponse.ToProduct();
            return responseProduct;
        }
    }
}
