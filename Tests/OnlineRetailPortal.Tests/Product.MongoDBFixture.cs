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
        AddProductStoreRequest addProductRequest = new AddProductStoreRequest()
        {
            Id = "12WREVVFW",
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
            var product = await productStore.AddProductAsync(addProductRequest);

            Assert.Equal(product.Name, addProductRequest.Name);
        }

        [Fact]
        public async Task Add_Product_Should_Not_Add_When_Database_Is_Down()
        {          
            ProductStore productStore = new ProductStore();
            Exception ex= await Assert.ThrowsAsync<BaseException>(()=> productStore.AddProductAsync(addProductRequest));

            Assert.Equal("Unexpected Error Occured, Please Try Again Later", ex.Message);
        }


    }
}
