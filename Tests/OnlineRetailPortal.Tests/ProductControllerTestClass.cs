using OnlineRetailPortal.Contracts;
using OnlineRetailPortal.Mock;
using OnlineRetailPortal.Web;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace OnlineRetailPortal.Tests
{
    public class ProductControllerTestClass
    {
        static IProductStoreFactory storeFactory= new ProductStoreFactory();
        private IProductService _productService = new Services.ProductService(storeFactory);
        [Fact]
        public async void AddProduct_Request_With_Valid_Request_Format()
        { 
            Web.ProductsController productsController = new ProductsController(_productService);
            var addProductRequest = GetRequest();
            var expectedResponse = GetExpectedResponse();
            Web.AddProductResponse actualResponse =  await productsController.AddProductAsync(addProductRequest);

            Assert.Equal(expectedResponse.SellerId, actualResponse.SellerId);
            //Assert.Equal(expectedResponse.Name, actualResponse.Name);
            //Assert.Equal(expectedResponse.Description, actualResponse.Description);
            //Assert.Equal(expectedResponse.HeroImage.Url, actualResponse.HeroImage.Url);
          //  Assert.Equal(expectedResponse.Price.Amount, actualResponse.Price.Amount);
            //Assert.Equal(expectedResponse.Price.IsNegotiable, actualResponse.Price.IsNegotiable);
            //Assert.Equal(expectedResponse.Status, actualResponse.Status);
            //Assert.Equal(expectedResponse.PostDateTime.ToString(), actualResponse.PostDateTime.ToString());
            //for (var i = 0; i < actualResponse.Images.Count; i++)
            //    Assert.Equal(expectedResponse.Images[i].Url, actualResponse.Images[i].Url);
            //Assert.Equal(expectedResponse.PurchasedDate.ToString(), actualResponse.PurchasedDate.ToString());
            //Assert.Equal(expectedResponse.PickupAddress.Line1, actualResponse.PickupAddress.Line1);
            //Assert.Equal(expectedResponse.PickupAddress.Line2, actualResponse.PickupAddress.Line2);
            //Assert.Equal(expectedResponse.PickupAddress.City, actualResponse.PickupAddress.City);
            //Assert.Equal(expectedResponse.PickupAddress.State, actualResponse.PickupAddress.State);
            //Assert.Equal(expectedResponse.PickupAddress.Pincode, actualResponse.PickupAddress.Pincode);
        }


        private Web.AddProductResponse GetExpectedResponse()
        {
            Web.AddProductResponse addProductResponse = new Web.AddProductResponse
            {
                SellerId = "P123",
                Name = "Bottle",
                Description = "Green Bottle",
                HeroImage =  "example.com" ,
                Price = new Web.Price {Money = new Web.Money( 99.99,  "INR" ), IsNegotiable = true },
                Category = "Other",
                Images = new List<string>() { "ex.com" },
                PurchasedDate = DateTime.Now,
                PickupAddress = new Web.Address
                {
                    Line1 = "ABC",
                    Line2 = "XYZ",
                    City = "Pune",
                    Pincode = 411001,
                    State = "Maharashtra"
                }
            };

            return addProductResponse;
        }

        private Web.AddProductRequest GetRequest()
        {
            Web.AddProductRequest addProductRequest = new Web.AddProductRequest()
            {
                SellerId="P123",
                Name = "Bottle",
                Description = "Green Bottle",
                HeroImage = "example.com",
                Price = new Web.Price { Money = new Web.Money( 99.99, "INR"), IsNegotiable = true },
                Category = "Other",
                Images = new List<string>() { "ex.com"},
                PurchasedDate = DateTime.Now,
                PickupAddress = new Web.Address
                {
                    Line1 = "ABC",
                    Line2 = "XYZ",
                    City = "Pune",
                    Pincode = 411001,
                    State = "Maharashtra"
                }
            };
            return addProductRequest;
        }
    }
}
