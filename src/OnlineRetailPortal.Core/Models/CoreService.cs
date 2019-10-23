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
        Translator translator;

        public CoreService(IProductStore productStore)
        {
            this.productStore = productStore;
            translator = new Translator();
        }

        public async Task<CorePostResponse> AddProduct(CorePostRequest product)
        {
            //translate product to request
            EntityPostRequest entityPostRequest = translator.ToEntityRequest(product);
            //call product store method
            EntityPostResponse entityPostResponse = await productStore.PostProductAsync(entityPostRequest);
            //translate response back to product
            CorePostResponse responseProduct = translator.ToProduct(entityPostResponse);
            return responseProduct;
        }
    }
}
