using OnlineRetailPortal.Web;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace OnlineRetailPortal.Tests
{
    public class ProductControllerTestClass
    {
        [Fact]
        public async void Test_to_check_add_product_request()
        {
            AddProductRequest addProductRequest = new AddProductRequest();
            addProductRequest.SellerId = "";
        }
     }
}
