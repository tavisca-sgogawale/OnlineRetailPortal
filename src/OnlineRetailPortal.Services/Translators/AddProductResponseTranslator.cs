using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineRetailPortal.Services.Translators
{
    public static class AddProductResponseTranslator
    {
        public static Contracts.AddProductResponse ToWeb()
        {
            Contracts.AddProductResponse request = new Contracts.AddProductResponse();
        }
    }
}
