using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineRetailPortal.Services.Translators
{
    public static class AddProductResponseTranslator
    {
        public static Contracts.AddProductResponse ToWeb(this Core.Product product)
        {
            Contracts.AddProductResponse addProductResponse = new Contracts.AddProductResponse();
            addProductResponse.Product.Name = product.Name;
            return addProductResponse;
        }
    }
}
