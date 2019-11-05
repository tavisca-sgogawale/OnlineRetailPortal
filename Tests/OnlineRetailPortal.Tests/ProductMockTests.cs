using OnlineRetailPortal.Contracts;
using System;
using Xunit;
using System.Collections.Generic;
using System.Threading.Tasks;
using OnlineRetailPortal.Mock;

namespace OnlineRetailPortal.Tests
{
    public class ProductMockTests
    {
        [Fact]
        public async void AddProduct_With_Valid_Request_Should_Be_Added_Successfully()
        {
            AddProductStoreRequest entityPostRequest = GetRequest();

            AddProductStoreResponse expectedResponse = GetExpectedResponse();

            MockProductStore mockProductStore = new MockProductStore();

            AddProductStoreResponse actualResponse = await mockProductStore.AddProductAsync(entityPostRequest);

            Assert.Equal(expectedResponse.SellerId, actualResponse.SellerId);
            Assert.Equal(expectedResponse.Name, actualResponse.Name);
            Assert.Equal(expectedResponse.Description, actualResponse.Description);
            Assert.Equal(expectedResponse.HeroImage.Url, actualResponse.HeroImage.Url);
            Assert.Equal(expectedResponse.Price.Money.Amount, actualResponse.Price.Money.Amount);
            Assert.Equal(expectedResponse.Price.Money.Currency, actualResponse.Price.Money.Currency);
            Assert.Equal(expectedResponse.Price.IsNegotiable, actualResponse.Price.IsNegotiable);
            Assert.Equal(expectedResponse.Category, actualResponse.Category);
            Assert.Equal(expectedResponse.Status, actualResponse.Status);
            Assert.Equal(expectedResponse.PostDateTime.ToString(), actualResponse.PostDateTime.ToString());
            Assert.Equal(expectedResponse.ExpirationDate.ToString(), actualResponse.ExpirationDate.ToString());
            for (var i = 0; i < actualResponse.Images.Count; i++)
                Assert.Equal(expectedResponse.Images[i].Url, actualResponse.Images[i].Url);
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
            request.Images = new List<Contracts.Image>();
            request.PurchasedDate = null;
            request.PickupAddress = null;

            var expectedResponse = GetExpectedResponse();
            expectedResponse.Images = new List<Contracts.Image>();
            expectedResponse.PurchasedDate = null;
            expectedResponse.PickupAddress = null;

            MockProductStore mockProductStore = new MockProductStore();

            var actualResponse = await mockProductStore.AddProductAsync(request);

            Assert.Equal(expectedResponse.SellerId, actualResponse.SellerId);
            Assert.Equal(expectedResponse.Name, actualResponse.Name);
            Assert.Equal(expectedResponse.Description, actualResponse.Description);
            Assert.Equal(expectedResponse.HeroImage.Url, actualResponse.HeroImage.Url);
            Assert.Equal(expectedResponse.Price.Money.Amount, actualResponse.Price.Money.Amount);
            Assert.Equal(expectedResponse.Price.Money.Currency, actualResponse.Price.Money.Currency);
            Assert.Equal(expectedResponse.Price.IsNegotiable, actualResponse.Price.IsNegotiable);
            Assert.Equal(expectedResponse.Category, actualResponse.Category);
            Assert.Equal(expectedResponse.Status, actualResponse.Status);
            Assert.Equal(expectedResponse.PostDateTime.ToString(), actualResponse.PostDateTime.ToString());
            Assert.Equal(expectedResponse.ExpirationDate.ToString(), actualResponse.ExpirationDate.ToString());
            for (var i = 0; i < actualResponse.Images.Count; i++)
                Assert.Equal(expectedResponse.Images[i].Url, actualResponse.Images[i].Url);
            Assert.Equal(expectedResponse.PurchasedDate.ToString(), actualResponse.PurchasedDate.ToString());
            Assert.Null(actualResponse.PickupAddress);
        }

        [Fact]
        public async void AddProduct_With_Null_Request_Should_Not_Be_Added_Successfully()
        {
            var request = GetRequest();

            request.Name = null;

            AddProductStoreResponse actualResponse = null;

            MockProductStore mockProductStore = new MockProductStore();
            try
            {
                actualResponse = await mockProductStore.AddProductAsync(request);
            }
            catch(Exception)
            {
                Assert.Null(actualResponse);
            }
        }

        private AddProductStoreResponse GetExpectedResponse()
        {
            AddProductStoreResponse response = new AddProductStoreResponse
            {
                SellerId = "1",
                ProductId = null,
                Name = "Bottle",
                Description = "Green Bottle",
                HeroImage = new Contracts.Image { Url = "example.com" },
                Price = new Contracts.Price { Money = new Contracts.Money (99.99, "INR" ), IsNegotiable = false },
                Category = Contracts.Category.Other,
                Status = Contracts.Status.Active,
                PostDateTime = DateTime.Now,
                ExpirationDate = DateTime.Now.AddDays(30),
                Images = new List<Contracts.Image>() { new Contracts.Image { Url = "ex.com" } },
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

        private AddProductStoreRequest GetRequest()
        {
            AddProductStoreRequest request = new AddProductStoreRequest
            {
                SellerId = "1",
                Name = "Bottle",
                Description = "Green Bottle",
                HeroImage = new Contracts.Image { Url = "example.com" },
                Price = new Contracts.Price {Money = new Contracts.Money(99.99, "INR"), IsNegotiable = false },
                Category = Contracts.Category.Other,
                Images = new List<Contracts.Image>() { new Contracts.Image { Url = "ex.com" } },
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
