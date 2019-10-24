using OnlineRetailPortal.Contracts;
using System;
using Xunit;
using System.Collections.Generic;
using OnlineRetailPortal.Mock.Models;
using System.Threading.Tasks;

namespace OnlineRetailPortal.Tests
{
    public class MockTestClass
    {
        [Fact]
        public async void Test_to_check_product_added_in_database()
        {
            EntityPostRequest entityPostRequest = new EntityPostRequest
            {
                Id = "P101",
                Name = "Bottle",
                Description = "Green Bottle",
                HeroImage = new Image { Url = "example.com" },
                Price = new Price { Amount = 99.99, IsNegotiable = false },
                Category = Category.Others,
                Images = new List<Image>() { new Image { Url = "ex.com" } },
                PurchasedDate = new DateTime(2010, 7, 7),
                PickupAddress = new Address
                {
                    Line1 = "ABC",
                    Line2 = "XYZ",
                    City = "Pune",
                    Pincode = 411001,
                    State = "Maharashtra"
                }
            };

            MockProductStore mockProductStore = new MockProductStore();

            EntityPostResponse actualResponse = await mockProductStore.PostProductAsync(entityPostRequest);

            EntityPostResponse expectedResponse = new EntityPostResponse
            {
                Id = "P101",
                Name = "Bottle",
                Description = "Green Bottle",
                HeroImage = new Image { Url = "example.com" },
                Price = new Price { Amount = 99.99, IsNegotiable = false },
                Category = Category.Others,
                Status = Status.Active,
                PostDateTime = DateTime.Now,
                ExpirationDate = DateTime.Now.AddDays(30),
                Images = new List<Image>() { new Image { Url = "ex.com" } },
                PurchasedDate = new DateTime(2010, 7, 7),
                PickupAddress = new Address
                {
                    Line1 = "ABC",
                    Line2 = "XYZ",
                    City = "Pune",
                    Pincode = 411001,
                    State = "Maharashtra"
                }
            };

            Assert.Equal(expectedResponse.ToString(), actualResponse.ToString());
        }
    }
}
