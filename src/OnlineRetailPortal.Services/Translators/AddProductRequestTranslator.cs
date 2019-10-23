using System;
using System.Collections.Generic;
using System.Text;
using OnlineRetailPortal.Core;

namespace OnlineRetailPortal.Services.Translators
{
    public static class AddProductRequestTranslator
    {
        public static Core.CorePostRequest ToCore(this Contracts.AddProductRequest addProductRequest)
        {
            Core.CorePostRequest corePostRequest = new CorePostRequest();
            corePostRequest.Name = addProductRequest.Product.Name;
            return corePostRequest;
        }
    }
}
