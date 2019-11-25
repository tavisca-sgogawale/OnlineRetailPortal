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
        private static IProductStoreFactory _storeFactory = new ProductStoreFactory();
        private static IProductService _productService = new Services.ProductService(_storeFactory);
        ProductsController _productsController = new ProductsController(_productService);
        [Fact]
        public async void GetProducts_PageNoAndPageSizeGiven_ShouldReturnListOfProductsWithPageInfo()
        {
            //Arrenge 
            int pageNo = 1;
            int pageSize = 1;

            GetProductsResponse expectedResponse = GetExpectedResponse();

            //Act
            GetProductsResponse actualResponse = await _productsController.GetProductsAsync(pageNo, pageSize,null);

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
                Assert.Equal(expectedResponse.Products[i].Price.Amount, actualResponse.Products[i].Price.Amount);
            }
        }
        [Fact]
        public async void GetProduct_ProductIdGiven_ShouldShowRespectiveProductDetails()
        {
            //Arrenge 
            Web.GetProductResponse expectedResponse = GetExpectedProduct();

            //Act
            Web.GetProductResponse actualResponse = await _productsController.GetProductAsync("101");

            //Test
            {
                Assert.Equal(expectedResponse.Product.Id, actualResponse.Product.Id);
                Assert.Equal(expectedResponse.Product.HeroImage, actualResponse.Product.HeroImage);
                Assert.Equal(expectedResponse.Product.PostDateTime.ToString(), actualResponse.Product.PostDateTime.ToString());
                Assert.Equal(expectedResponse.Product.Name, actualResponse.Product.Name);
                Assert.Equal(expectedResponse.Product.Price.IsNegotiable, actualResponse.Product.Price.IsNegotiable);
                Assert.Equal(expectedResponse.Product.Price.Amount, actualResponse.Product.Price.Amount);

            }
        }
        private Web.GetProductResponse GetExpectedProduct()
        {
            return new Web.GetProductResponse()
            {
                Product = new Web.Product()
                {
                    SellerId = "1",
                    Id = "101",
                    Name = "Mobile",
                    Price = new Web.Price
                    {
                        Amount = 200,
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
        public async void Should_ThrowException_When_ProductId_is_Ivalid()
        {
            var expectedErrorMsg = "Product does not exist with \"1q1\" product id.";
            var exception = await Assert.ThrowsAnyAsync<BaseException>(() => _productsController.GetProductAsync("1q1"));
            Assert.Equal(expectedErrorMsg, exception.Message);
        }
        private GetProductsResponse GetExpectedResponse()
        {
            return new GetProductsResponse()
            {
                Products = new List<Web.Product>()
                {
                 new  Web.Product{SellerId="1",Id="101",Name="Mobile", Price=new Web.Price{

                        Amount = 200,
                        IsNegotiable=true}, Category="Mobile",
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
