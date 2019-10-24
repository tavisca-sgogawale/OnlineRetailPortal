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
    public class CoreTestClass
    {
        [Fact]
        public async void Test_to_check_aad_product_function_of_core()
        {
            Core.Product requestProduct = new Core.Product(new MockProductStore())
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

            Core.Product actualResponse = await requestProduct.AddProduct(requestProduct);

            Core.Product expectedResponse = new Core.Product
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

            Assert.Equal(expectedResponse.ToString(), actualResponse.ToString());
        }
    }
}
