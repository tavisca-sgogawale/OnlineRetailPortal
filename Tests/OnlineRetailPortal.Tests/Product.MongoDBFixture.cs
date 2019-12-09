﻿using OnlineRetailPortal.Contracts;
using OnlineRetailPortal.MongoDBStore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace OnlineRetailPortal.Tests
{
    public class Product
    {
        ProductEntity demoProductEntity = new ProductEntity()
        {
            Id = "111",
            SellerId = "222",
            Name = "IphoneUpdated",
            Description = "Iphone 1 year old",
            HeroImage = "www.image1.com",
            Price = new Price() { Money = new Money(123, "asdas"), IsNegotiable = true },
            Category = new Category() { Name = "Book", Tags = new List<string>() { "book", "copy" } },
            Images = new List<string>() { "www.image1.com",
                "www.image1.com",
                "www.image1.com" },
            Status = Status.Active,
            PurchasedDate = DateTime.Now,
            PickupAddress = new Address()
            {
                Line1 = "123 Street",
                Line2 = "MOngo road",
                City = "Pune",
                State = "Maharashtra",
                Pincode = 123213
            },
            ExpirationDate = DateTime.Now.AddDays(30),
            PostDateTime = DateTime.Now
        };

        ProductEntity demoProductEntity2 = new ProductEntity()
        {
            Id = "112",
            SellerId = "222",
            Name = "IphoneUpdated",
            Description = "Iphone 1 year old",
            HeroImage = "www.image1.com",
            Price = new Price() { Money = new Money(123, "asdas"), IsNegotiable = true },
            Category = new Category() { Name = "Book", Tags = new List<string>() { "book", "copy" } },
            Images = new List<string>() { "www.image1.com",
                "www.image1.com",
                "www.image1.com" },
            Status = Status.Active,
            PurchasedDate = DateTime.Now,
            PickupAddress = new Address()
            {
                Line1 = "123 Street",
                Line2 = "MOngo road",
                City = "Pune",
                State = "Maharashtra",
                Pincode = 123213
            },
            ExpirationDate = DateTime.Now.AddDays(30),
            PostDateTime = DateTime.Now
        };

        [Fact]
        public async Task Add_Product_Should_Return_Added_Product()
        {
            MongoProductStore productStore = new MongoProductStore();
            var product = await productStore.AddProductAsync(demoProductEntity);

            Assert.Equal(product.Name, demoProductEntity.Name);
            Assert.Equal(product.SellerId, demoProductEntity.SellerId);
            Assert.Equal(product.Name, demoProductEntity.Name);
            Assert.Equal(product.Description, demoProductEntity.Description);
            Assert.Equal(product.HeroImage, demoProductEntity.HeroImage);
            Assert.Equal(product.Price.Money.Amount, demoProductEntity.Price.Money.Amount);
            Assert.Equal(product.Price.Money.Currency, demoProductEntity.Price.Money.Currency);
            Assert.Equal(product.Price.IsNegotiable, demoProductEntity.Price.IsNegotiable);
            Assert.Equal(product.Category, demoProductEntity.Category);
            Assert.Equal(product.Status, demoProductEntity.Status);
            Assert.Equal(product.PostDateTime.ToString(), demoProductEntity.PostDateTime.ToString());
            Assert.Equal(product.ExpirationDate.ToString(), demoProductEntity.ExpirationDate.ToString());
            for (var i = 0; i < demoProductEntity.Images.Count; i++)
                Assert.Equal(product.Images[i], demoProductEntity.Images[i]);
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
            MongoProductStore productStore = new MongoProductStore();
            Exception ex = await Assert.ThrowsAsync<BaseException>(() => productStore.AddProductAsync(demoProductEntity));

            Assert.Equal("Unexpected Error Occured, Please Try Again Later", ex.Message);
        }

        [Fact]
        public async Task Get_Products_Should_Return_List_Of_Products()
        {
            MongoProductStore productStore = new MongoProductStore();

            GetProductsStoreEntity getProductsStoreEntity = new GetProductsStoreEntity()
            {
                PagingInfo = new PagingInfo() { PageNumber = 1, PageSize = 20, TotalPages = 100 }
            };

            var response = await productStore.GetProductsAsync(getProductsStoreEntity);
            Assert.Equal(1, response.Products.Count);
        }

        [Fact]
        public async Task Get_Product_By_ID_Should_Return_Particular_Product()
        {
            MongoProductStore productStore = new MongoProductStore();
            var product = await productStore.GetProductAsync(demoProductEntity.Id);
            Assert.Equal(product.Product.Id, demoProductEntity.Id);
        }

        [Fact]
        public async Task Get_Product_By_ID_Should_Return_Exception_If_Id_IS_Invalid()
        {
            MongoProductStore productStore = new MongoProductStore();
            Exception ex = await Assert.ThrowsAsync<BaseException>(() => productStore.GetProductAsync(demoProductEntity.Id + "INVALID_ID"));
            Assert.Equal("Requested Id is not found.", ex.Message);
        }

        [Fact]
        public async Task Update_Product_By_ID_Should_Update_The_Correct_Product()
        {
            MongoProductStore productStore = new MongoProductStore();
            var result = await productStore.UpdateProductAsync(demoProductEntity);
            Assert.Equal(result.Name, demoProductEntity.Name);
        }

        [Fact]
        public async Task Update_Product_By_ID_Should_Not_Update_If_Id_Is_Wrong()
        {
            MongoProductStore productStore = new MongoProductStore();
            Exception ex = await Assert.ThrowsAsync<BaseException>(() => productStore.UpdateProductAsync(demoProductEntity2));
            Assert.Equal("Requested Id is not found.", ex.Message);

        }
    }
}
