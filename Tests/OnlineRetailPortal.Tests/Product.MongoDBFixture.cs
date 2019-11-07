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

        [Fact]
        public async Task Add_Product_Should_Return_Added_Product()
        {
            AddProductStoreRequest addProductRequest = new AddProductStoreRequest()
            {
                Id = "123RE2DQW",
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
                { Line1 = "123 Street", 
                  Line2 = "MOngo road",
                  City = "Pune",
                  State = "Maharashtra",
                  Pincode = 123213 }

            };

            ProductStore productStore = new ProductStore();
            var product = await productStore.AddProductAsync(addProductRequest);

            Assert.Equal(product.Id, addProductRequest.Id);
        }


    }
}
