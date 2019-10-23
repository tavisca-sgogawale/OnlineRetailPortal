using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineRetailPortal.Services.Translators
{
    public static class AddProductResponseTranslator
    {
        public static Contracts.AddProductResponse ToWeb(this Core.CorePostResponse corePostResponse)
        {
            Contracts.AddProductResponse addProductResponse = new Contracts.AddProductResponse();
            addProductResponse.Product.Name = corePostResponse.Name;
            return addProductResponse;
        }
    }
}
