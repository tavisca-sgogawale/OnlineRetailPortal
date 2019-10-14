using ERPBackend.Models;
using System;
using System.Collections.Generic;
using Xunit;

namespace ERPBackend.Tests
{
    public class MockProductDatabseFixture
    {
        [Fact]
        public void Should_display_list()
        {
            List<Product> expectedProducts = new List<Product>
        {
            new Product{Id=101,Name="Mobile", Price=new Price{ Amount=1299.00, IsNegotiable=true}, Category=Category.Mobiles,
                HeroImage =new Image{Url = "https://www.olx.in/item/11-pro-max-64-gb-full-box-iid-1540782056/gallery"},
                Description ="11 pro max 64 gb full box", Images=null,
                PickupAddress =new Address{Line1="abc",Line2="xyz", City="Pune",State="Maharashtra", Pincode=411038 },
                PostDateTime =  new DateTime(2019,12,1), PurchasedDate = new DateTime(2019,12,1), Status = Status.Active, UserId = "1118" },

            new Product{Id=102,Name="Bottle", Price=new Price{ Amount=999.00, IsNegotiable=true}, Category=Category.Others,
                HeroImage =new Image{Url = "https://www.olx.in/item/11-pro-max-64-gb-full-box-iid-1540782056/gallery"},
                Description ="Tavisca green color bottle", Images=null,
                PickupAddress =new Address{Line1="abc",Line2="xyz", City="Pune",State="Maharashtra", Pincode=411038 },
                PostDateTime =  new DateTime(2019,12,1), PurchasedDate = new DateTime(2019,12,1), Status = Status.Active, UserId = "1118" },

        };
            MockProductDatabase productDatabase = new MockProductDatabase();
            List<Product> allProducts = productDatabase.GetProductsByPage(1, 20);
            Assert.Equal(allProducts.ToString(), expectedProducts.ToString());


        }
        [Fact]
        public void Should_display_product()
        {
            Product expectedProduct = new Product
            {
                Id = 102,
                Name = "Bottle",
                Price = new Price { Amount = 999.00, IsNegotiable = true },
                Category = Category.Others,
                HeroImage = new Image { Url = "https://www.olx.in/item/11-pro-max-64-gb-full-box-iid-1540782056/gallery" },
                Description = "Tavisca green color bottle",
                Images = null,
                PickupAddress = new Address { Line1 = "abc", Line2 = "xyz", City = "Pune", State = "Maharashtra", Pincode = 411038 },
                PostDateTime = new DateTime(2019, 12, 1),
                PurchasedDate = new DateTime(2019, 12, 1),
                Status = Status.Active,
                UserId = "1118"
            };
           
            MockProductDatabase productDatabase = new MockProductDatabase();
            Product product = productDatabase.GetProductById(102);
            Assert.Equal(product.ToString(), expectedProduct.ToString());


        }
    }
  
}
