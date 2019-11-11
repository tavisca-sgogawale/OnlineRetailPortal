using Moq;
using OnlineRetailPortal.Contracts;
using OnlineRetailPortal.Mock;
using OnlineRetailPortal.Web;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xunit;

namespace OnlineRetailPortal.Tests
{
    public class ProductControllerFixture
    {
        private static IProductStoreFactory storeFactory = new ProductStoreFactory();
        private static IProductService _productService = new Services.ProductService(storeFactory);
        ProductsController productsController = new ProductsController(_productService);
        [Fact]
        public async void ToGetListOfProducts()
        {
            //Arrenge 
            int pageNo = 1;
            int pageSize = 1;

            GetProductsResponse expectedResponse = GetExpectedResponse();

            //Act
            GetProductsResponse actualResponse = await productsController.GetProductsAsync(pageNo, pageSize);

            //Test
            Assert.Equal(expectedResponse.PagingInfo.PageNumber, actualResponse.PagingInfo.PageNumber);
            Assert.Equal(expectedResponse.PagingInfo.PageSize, actualResponse.PagingInfo.PageSize);
            for (var i = 0; i < expectedResponse.Products.Count; i++)
            {
                Assert.Equal(expectedResponse.Products[i].Id, actualResponse.Products[i].Id);
                Assert.Equal(expectedResponse.Products[i].HeroImage, actualResponse.Products[i].HeroImage);
                Assert.Equal(expectedResponse.Products[i].PostDateTime.ToString(), actualResponse.Products[i].PostDateTime.ToString());
                Assert.Equal(expectedResponse.Products[i].Name, actualResponse.Products[i].Name);
                Assert.Equal(expectedResponse.Products[i].Price.IsNegotiable, actualResponse.Products[i].Price.IsNegotiable);
                Assert.Equal(expectedResponse.Products[i].Price.Money.Amount, actualResponse.Products[i].Price.Money.Amount);
                Assert.Equal(expectedResponse.Products[i].Price.Money.Currency, actualResponse.Products[i].Price.Money.Currency);
            }
        }
        [Fact]
        public async void To_product_By_Id()
        {
            //Arrenge 
            GetProductResponse expectedResponse = GetExpectedProduct();

            //Act
            GetProductResponse actualResponse = await productsController.GetProductAsync("101");

            //Test
            {
                Assert.Equal(expectedResponse.Product.Id, actualResponse.Product.Id);
                Assert.Equal(expectedResponse.Product.HeroImage, actualResponse.Product.HeroImage);
                Assert.Equal(expectedResponse.Product.PostDateTime.ToString(), actualResponse.Product.PostDateTime.ToString());
                Assert.Equal(expectedResponse.Product.Name, actualResponse.Product.Name);
                Assert.Equal(expectedResponse.Product.Price.IsNegotiable, actualResponse.Product.Price.IsNegotiable);
                Assert.Equal(expectedResponse.Product.Price.Money.Amount, actualResponse.Product.Price.Money.Amount);
                Assert.Equal(expectedResponse.Product.Price.Money.Currency, actualResponse.Product.Price.Money.Currency);
            }
        }
        private GetProductResponse GetExpectedProduct()
        {
            return new GetProductResponse()
            {
                Product = new Web.Product()
                {
                    SellerId = "1",
                    Id = "101",
                    Name = "Mobile",
                    Price = new Web.Price
                    {
                        Money = new Web.Money()
                        {
                            Amount = 200,
                            Currency = "INR"
                        },
                        IsNegotiable = true
                    },
                    Category = "Mobile",
                    HeroImage = "https://www.olx.in/item/11-pro-max-64-gb-full-box-iid-1540782056/gallery",
                    Description = "11 pro max 64 gb full box",
                    Images = new List<string>() { "https://www.olx.in/item/11-pro-max-64-gb-full-box-iid-1540782056/gallery", "https://www.olx.in/item/11-pro-max-64-gb-full-box-iid-1540782056/gallery" },
                    PickupAddress = new Web.Address { Line1 = "abc", Line2 = "xyz", City = "Pune", State = "Maharashtra", Pincode = 411038 },
                    PostDateTime = new DateTime(2019, 1, 1),
                    ExpirationDate = new DateTime(2019, 12, 1).AddDays(30),
                    PurchasedDate = DateTime.Now,
                    Status = "Active"
                }
            };
        }

        [Fact]
        public async void Test_for_passing_invalid_product_id()
        {
            var expectedErrorMsg = "Product does not exist with \"1q1\" product id.";
           var exception = await Assert.ThrowsAnyAsync<BaseException>(() => productsController.GetProductAsync("1q1"));
           Assert.Equal(expectedErrorMsg, exception.Message);
        }
        private GetProductsResponse GetExpectedResponse()
        {
            return new GetProductsResponse()
            {
                Products = new List<Web.Product>()
                {
                 new  Web.Product{SellerId="1",Id="101",Name="Mobile", Price=new Web.Price{Money = new Web.Money()
                    {
                        Amount = 200,
                        Currency = "INR"
                    }, IsNegotiable=true}, Category="Mobile",
                HeroImage = "https://www.olx.in/item/11-pro-max-64-gb-full-box-iid-1540782056/gallery",
                Description ="11 pro max 64 gb full box", Images= new List<string>(){"https://www.olx.in/item/11-pro-max-64-gb-full-box-iid-1540782056/gallery","https://www.olx.in/item/11-pro-max-64-gb-full-box-iid-1540782056/gallery" },
                PickupAddress =new Web.Address{Line1="abc",Line2="xyz", City="Pune",State="Maharashtra", Pincode=411038 },
                PostDateTime =  new DateTime(2019,1,1),ExpirationDate = new DateTime(2019,12,1).AddDays(30), PurchasedDate = DateTime.Now, Status = "Active" }
                },
                PagingInfo = new Web.PagingInfo()
                {
                    PageNumber = 1,
                    PageSize = 1,
                    TotalPages = 4
                }
            };
        }
    }
}
