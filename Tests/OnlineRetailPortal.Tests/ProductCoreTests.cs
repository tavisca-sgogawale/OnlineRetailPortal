using OnlineRetailPortal.Contracts;
using OnlineRetailPortal.Core;
using OnlineRetailPortal.Mock;
using OnlineRetailPortal.Mock.Models;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace OnlineRetailPortal.Tests
{
    public class ProductCoreTests
    {
        [Fact]
        public async void AddProduct_With_Valid_Request_Should_Be_Added_Successfully()
        {
            Core.Product requestProduct = GetRequest();

            Core.Product expectedResponse = GetExpectedResponse();

            Core.Product actualResponse = await requestProduct.AddProductAsync(requestProduct);

            Assert.Equal(expectedResponse.Id, actualResponse.Id);
            Assert.Equal(expectedResponse.Name, actualResponse.Name);
            Assert.Equal(expectedResponse.Description, actualResponse.Description);
            Assert.Equal(expectedResponse.HeroImage.Url,actualResponse.HeroImage.Url);
            Assert.Equal(expectedResponse.Price.Amount, actualResponse.Price.Amount);
            Assert.Equal(expectedResponse.Price.IsNegotiable, actualResponse.Price.IsNegotiable);
            Assert.Equal(expectedResponse.Category, actualResponse.Category);
            Assert.Equal(expectedResponse.Status, actualResponse.Status);
            Assert.Equal(expectedResponse.PostDateTime.ToString(), actualResponse.PostDateTime.ToString());
            Assert.Equal(expectedResponse.ExpirationDate.ToString(), actualResponse.ExpirationDate.ToString());
            for(var i=0; i<actualResponse.Images.Count;i++)
                Assert.Equal(expectedResponse.Images[i].Url, actualResponse.Images[i].Url);
            Assert.Equal(expectedResponse.PurchasedDate.ToString(), actualResponse.PurchasedDate.ToString());
            Assert.Equal(expectedResponse.PickupAddress.Line1, actualResponse.PickupAddress.Line1);
            Assert.Equal(expectedResponse.PickupAddress.Line2, actualResponse.PickupAddress.Line2);
            Assert.Equal(expectedResponse.PickupAddress.City, actualResponse.PickupAddress.City);
            Assert.Equal(expectedResponse.PickupAddress.State, actualResponse.PickupAddress.State);
            Assert.Equal(expectedResponse.PickupAddress.Pincode, actualResponse.PickupAddress.Pincode);

        }

        private Core.Product GetExpectedResponse()
        {
            Core.Product product = new Core.Product
            {
                Id = "P101",
                Name = "Bottle",
                Description = "Green Bottle",
                HeroImage = new Core.Image { Url = "example.com" },
                Price = new Core.Price { Amount = 99.99, IsNegotiable = false },
                Category = Core.Category.Others,
                Status = Core.Status.Active,
                PostDateTime = DateTime.Now,
                ExpirationDate = DateTime.Now.AddDays(30),
                Images = new List<Core.Image>() { new Core.Image { Url = "ex.com" } },
                PurchasedDate = new DateTime(2010, 7, 7),
                PickupAddress = new Core.Address
                {
                    Line1 = "ABC",
                    Line2 = "XYZ",
                    City = "Pune",
                    Pincode = 411001,
                    State = "Maharashtra"
                }
            };

            return product;
        }

        private Core.Product GetRequest()
        {
            Core.Product product = new Core.Product(new MockProductStore())
            {
                Id = "P101",
                Name = "Bottle",
                Description = "Green Bottle",
                HeroImage = new Core.Image { Url = "example.com" },
                Price = new Core.Price { Amount = 99.99, IsNegotiable = false },
                Category = Core.Category.Others,
                Images = new List<Core.Image>() { new Core.Image { Url = "ex.com" } },
                PurchasedDate = new DateTime(2010, 7, 7),
                PickupAddress = new Core.Address
                {
                    Line1 = "ABC",
                    Line2 = "XYZ",
                    City = "Pune",
                    Pincode = 411001,
                    State = "Maharashtra"
                }
            };

            return product;
        }
    }
}
