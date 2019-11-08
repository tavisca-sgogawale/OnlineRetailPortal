using OnlineRetailPortal.Contracts;
using OnlineRetailPortal.MongoDBStore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace OnlineRetailPortal.Tests
{
    public class Product
    {
        ProductEntity demoProductEntity = new ProductEntity()
        {
            Id = "984667PPZZ",
            SellerId = "IVDR12RED",
            Name = "Iphone",
            Description = "Iphone 1 year old",
            HeroImage = new Image() { Url = "www.image1.com" },
            Price = new Price() { Money = new Money(123, "asdas"), IsNegotiable = true },
            Category = Category.Book,
            Images = new List<Image>() { new Image() { Url = "www.image1.com" },
                                             new Image() { Url = "www.image1.com" },
                                             new Image() { Url = "www.image1.com" } },
            PurchasedDate = DateTime.Now,
            PickupAddress = new Address()
            {
                Line1 = "123 Street",
                Line2 = "MOngo road",
                City = "Pune",
                State = "Maharashtra",
                Pincode = 123213
            }

        };


        [Fact]
        public async Task Add_Product_Should_Return_Added_Product()
        {
            ProductStore productStore = new ProductStore();
            var product = await productStore.AddProductAsync(demoProductEntity);

            Assert.Equal(product.Name, demoProductEntity.Name);
            Assert.Equal(product.SellerId, demoProductEntity.SellerId);
            Assert.Equal(product.Name, demoProductEntity.Name);
            Assert.Equal(product.Description, demoProductEntity.Description);
            Assert.Equal(product.HeroImage.Url, demoProductEntity.HeroImage.Url);
            Assert.Equal(product.Price.Money.Amount, demoProductEntity.Price.Money.Amount);
            Assert.Equal(product.Price.Money.Currency, demoProductEntity.Price.Money.Currency);
            Assert.Equal(product.Price.IsNegotiable, demoProductEntity.Price.IsNegotiable);
            Assert.Equal(product.Category, demoProductEntity.Category);
            Assert.Equal(product.Status, demoProductEntity.Status);
            Assert.Equal(product.PostDateTime.ToString(), demoProductEntity.PostDateTime.ToString());
            Assert.Equal(product.ExpirationDate.ToString(), demoProductEntity.ExpirationDate.ToString());
            for (var i = 0; i < demoProductEntity.Images.Count; i++)
                Assert.Equal(product.Images[i].Url, demoProductEntity.Images[i].Url);
            Assert.Equal(product.PurchasedDate.ToString(), demoProductEntity.PurchasedDate.ToString());
            Assert.Equal(product.PickupAddress.Line1, demoProductEntity.PickupAddress.Line1);
            Assert.Equal(product.PickupAddress.Line2, demoProductEntity.PickupAddress.Line2);
            Assert.Equal(product.PickupAddress.City, demoProductEntity.PickupAddress.City);
            Assert.Equal(product.PickupAddress.State, demoProductEntity.PickupAddress.State);
            Assert.Equal(product.PickupAddress.Pincode, demoProductEntity.PickupAddress.Pincode);
        }

        [Fact]
        public async Task Add_Product_Should_Not_Add_When_Database_Is_Down()
        {
            ProductStore productStore = new ProductStore();
            Exception ex = await Assert.ThrowsAsync<BaseException>(() => productStore.AddProductAsync(demoProductEntity));

            Assert.Equal("Unexpected Error Occured, Please Try Again Later", ex.Message);
        }


    }
}
