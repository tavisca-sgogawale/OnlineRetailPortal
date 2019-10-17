using ERPBackend.Models;
using ERPBackend.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using ERPBackend.Services;
using ERPBackend.Contracts.Contracts;

namespace ERPBackend.Tests
{
    public class ProductServiceTest
    {
        [Fact]
        public void Test_when_product_added_to_list_should_return_correct_produc_data()
        {
            IProductService productService = new ProductService(new MockProductDatabase());

            Product actualProduct = new Product
            {
                Id = 134,
                Name = "Earphones",
                Price = new Price { Amount = 599.00, IsNegotiable = true },
                Category = Category.Electronics,
                HeroImage = new Image { Url = "https://www.olx.in/item/11-pro-max-64-gb-full-box-iid-1540782056/gallery" },
                Description = "LG HB 750",
                Images = null,
                PickupAddress = new Address { Line1 = "abc", Line2 = "xyz", City = "Pune", State = "Maharashtra", Pincode = 411038 },
                PurchasedDate = new DateTime(2019, 12, 1),
                UserId = "1118"
            };

            Product expectedProduct = productService.AddProduct(actualProduct);

            Assert.True(expectedProduct == actualProduct);

        }
    }
}