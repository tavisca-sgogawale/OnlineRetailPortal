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

            Assert.Equal(expectedResponse.ToString(), actualResponse.ToString());
        }

        private AddProductStoreResponse GetExpectedResponse()
        {
            AddProductStoreResponse response = new AddProductStoreResponse
            {
                Id = "P101",
                Name = "Bottle",
                Description = "Green Bottle",
                HeroImage = new Contracts.Image { Url = "example.com" },
                Price = new Contracts.Price { Amount = 99.99, IsNegotiable = false },
                Category = Contracts.Category.Others,
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
                Id = "P101",
                Name = "Bottle",
                Description = "Green Bottle",
                HeroImage = new Contracts.Image { Url = "example.com" },
                Price = new Contracts.Price { Amount = 99.99, IsNegotiable = false },
                Category = Contracts.Category.Others,
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