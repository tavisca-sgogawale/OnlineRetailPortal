using OnlineRetailPortal.Contracts;
using OnlineRetailPortal.Mock;
using System;
using System.Collections.Generic;
using Xunit;

namespace OnlineRetailPortal.Tests
{
    public class ProductMockTests
    {
        [Fact]
        public async void AddProduct_With_Valid_Request_Should_Be_Added_Successfully()
        {
            ProductEntity entityPostRequest = GetRequest();

            ProductEntity expectedResponse = GetExpectedResponse();

            MockProductStore mockProductStore = new MockProductStore();

            ProductEntity actualResponse = await mockProductStore.AddProductAsync(entityPostRequest);

            Assert.Equal(expectedResponse.SellerId, actualResponse.SellerId);
            Assert.Equal(expectedResponse.Name, actualResponse.Name);
            Assert.Equal(expectedResponse.Description, actualResponse.Description);
            Assert.Equal(expectedResponse.HeroImage, actualResponse.HeroImage);
            Assert.Equal(expectedResponse.Price.Money.Amount, actualResponse.Price.Money.Amount);
            Assert.Equal(expectedResponse.Price.Money.Currency, actualResponse.Price.Money.Currency);
            Assert.Equal(expectedResponse.Price.IsNegotiable, actualResponse.Price.IsNegotiable);
            Assert.Equal(expectedResponse.Category, actualResponse.Category);
            Assert.Equal(expectedResponse.Status, actualResponse.Status);
            Assert.Equal(expectedResponse.PostDateTime.ToString(), actualResponse.PostDateTime.ToString());
            Assert.Equal(expectedResponse.ExpirationDate.ToString(), actualResponse.ExpirationDate.ToString());
            for (var i = 0; i < actualResponse.Images.Count; i++)
                Assert.Equal(expectedResponse.Images[i], actualResponse.Images[i]);
            Assert.Equal(expectedResponse.PurchasedDate.ToString(), actualResponse.PurchasedDate.ToString());
            Assert.Equal(expectedResponse.PickupAddress.Line1, actualResponse.PickupAddress.Line1);
            Assert.Equal(expectedResponse.PickupAddress.Line2, actualResponse.PickupAddress.Line2);
            Assert.Equal(expectedResponse.PickupAddress.City, actualResponse.PickupAddress.City);
            Assert.Equal(expectedResponse.PickupAddress.State, actualResponse.PickupAddress.State);
            Assert.Equal(expectedResponse.PickupAddress.Pincode, actualResponse.PickupAddress.Pincode);
        }

        [Fact]
        public async void AddProduct_With_Null_Values_In_Optional_Field_In_Request_Should_Be_Added_Successfully()
        {
            var request = GetRequest();
            request.Images = new List<string>();
            request.PurchasedDate = null;
            request.PickupAddress = null;

            var expectedResponse = GetExpectedResponse();
            expectedResponse.Images = new List<string>();
            expectedResponse.PurchasedDate = null;
            expectedResponse.PickupAddress = null;

            MockProductStore mockProductStore = new MockProductStore();

            var actualResponse = await mockProductStore.AddProductAsync(request);

            Assert.Equal(expectedResponse.SellerId, actualResponse.SellerId);
            Assert.Equal(expectedResponse.Name, actualResponse.Name);
            Assert.Equal(expectedResponse.Description, actualResponse.Description);
            Assert.Equal(expectedResponse.HeroImage, actualResponse.HeroImage);
            Assert.Equal(expectedResponse.Price.Money.Amount, actualResponse.Price.Money.Amount);
            Assert.Equal(expectedResponse.Price.Money.Currency, actualResponse.Price.Money.Currency);
            Assert.Equal(expectedResponse.Price.IsNegotiable, actualResponse.Price.IsNegotiable);
            Assert.Equal(expectedResponse.Category, actualResponse.Category);
            Assert.Equal(expectedResponse.Status, actualResponse.Status);
            Assert.Equal(expectedResponse.PostDateTime.ToString(), actualResponse.PostDateTime.ToString());
            Assert.Equal(expectedResponse.ExpirationDate.ToString(), actualResponse.ExpirationDate.ToString());
            for (var i = 0; i < actualResponse.Images.Count; i++)
                Assert.Equal(expectedResponse.Images[i], actualResponse.Images[i]);
            Assert.Equal(expectedResponse.PurchasedDate.ToString(), actualResponse.PurchasedDate.ToString());
            Assert.Null(actualResponse.PickupAddress);
        }

        

        private ProductEntity GetExpectedResponse()
        {
            ProductEntity response = new ProductEntity
            {
                SellerId = "1",
                Id = null,
                Name = "Bottle",
                Description = "Green Bottle",
                HeroImage =  "example.com",
                Price = new Contracts.Price { Money = new Contracts.Money (99.99, "INR" ), IsNegotiable = false },
                Category = new Contracts.Category() { Name = "Other" },
                Status = Contracts.Status.Active,
                PostDateTime = DateTime.Now,
                ExpirationDate = DateTime.Now.AddDays(30),
                Images = new List<string>() { "ex.com" },
                PurchasedDate = new DateTime(2010, 7, 7),
                PickupAddress = new Contracts.Address
                {
                    Line1 = "ABC",
                    Line2 = "XYZ",
                    City = "Pune",
                    Pincode = 411001,
                    State = "Maharashtra"
                }
            };

            return response;
        }

        private ProductEntity GetRequest()
        {
            ProductEntity request = new ProductEntity
            {
                SellerId = "1",
                Name = "Bottle",
                Description = "Green Bottle",
                HeroImage = "example.com" ,
                Price = new Contracts.Price {Money = new Contracts.Money(99.99, "INR"), IsNegotiable = false },
                Category = new Contracts.Category() { Name = "Other" },
                Images = new List<string>() { "ex.com" },
                PurchasedDate = new DateTime(2010, 7, 7),
                PickupAddress = new Contracts.Address
                {
                    Line1 = "ABC",
                    Line2 = "XYZ",
                    City = "Pune",
                    Pincode = 411001,
                    State = "Maharashtra"
                }
            };

            return request;
        }
    }
}
