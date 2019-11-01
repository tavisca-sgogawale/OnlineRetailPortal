using OnlineRetailPortal.Contracts;
using OnlineRetailPortal.Web;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace OnlineRetailPortal.Tests
{
    public class ProductControllerTestClass
    {
        private IProductService _productService = new Services.ProductService();
        [Fact]
        //public async void AddProduct_Request_With_Valid_Request_Format()
        //{ 
        //    Web.ProductsController productsController = new ProductsController(_productService);
        //    var addProductRequest = GetRequest();
        //    var expectedResponse = GetExpectedResponse();
        //    Web.AddProductResponse actualResponse =  await productsController.AddProductAsync(addProductRequest);

        //    Assert.Equal(expectedResponse.SellerId, actualResponse.SellerId);
        //    Assert.Equal(expectedResponse.Name, actualResponse.Name);
        //    Assert.Equal(expectedResponse.Description, actualResponse.Description);
        //    Assert.Equal(expectedResponse.HeroImage.Url, actualResponse.HeroImage.Url);
        //    Assert.Equal(expectedResponse.Price.Amount, actualResponse.Price.Amount);
        //    Assert.Equal(expectedResponse.Price.IsNegotiable, actualResponse.Price.IsNegotiable);
        //    Assert.Equal(expectedResponse.Category, actualResponse.Category);
        //    Assert.Equal(expectedResponse.Status, actualResponse.Status);
        //    Assert.Equal(expectedResponse.PostDateTime.ToString(), actualResponse.PostDateTime.ToString());
        //    Assert.Equal(expectedResponse.ExpirationDate.ToString(), actualResponse.ExpirationDate.ToString());
        //    for (var i = 0; i < actualResponse.Images.Count; i++)
        //    Assert.Equal(expectedResponse.Images[i].Url, actualResponse.Images[i].Url);
        //    Assert.Equal(expectedResponse.PurchasedDate.ToString(), actualResponse.PurchasedDate.ToString());
        //    Assert.Equal(expectedResponse.PickupAddress.Line1, actualResponse.PickupAddress.Line1);
        //    Assert.Equal(expectedResponse.PickupAddress.Line2, actualResponse.PickupAddress.Line2);
        //    Assert.Equal(expectedResponse.PickupAddress.City, actualResponse.PickupAddress.City);
        //    Assert.Equal(expectedResponse.PickupAddress.State, actualResponse.PickupAddress.State);
        //    Assert.Equal(expectedResponse.PickupAddress.Pincode, actualResponse.PickupAddress.Pincode);
        //}

        private Web.AddProductResponse GetExpectedResponse()
        {
            Web.AddProductResponse addProductResponse = new Web.AddProductResponse
            {
                SellerId = "P123",
                Name = "Bottle",
                Description = "Green Bottle",
                HeroImage = new Web.Image { Url = "example.com" },
                Price = new Web.Price { Amount = 99.99, IsNegotiable = false },
                Category = Web.Category.Others,
                Status = Web.Status.Active,
                PostDateTime = DateTime.Now,
                ExpirationDate = DateTime.Now.AddDays(30),
                Images = new List<Web.Image>() { new Web.Image { Url = "ex.com" } },
                PurchasedDate = new DateTime(2010, 7, 7),
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
                HeroImage = new Web.Image { Url = "example.com" },
                Price = new Web.Price { Amount = 99.99, IsNegotiable = true },
                Category = Web.Category.Others,
                Images = new List<Web.Image>() { new Web.Image { Url = "ex.com" } },
                PurchasedDate = new DateTime(2010, 7, 7),
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
