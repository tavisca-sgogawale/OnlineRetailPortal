using OnlineRetailPortal.Contracts;
using OnlineRetailPortal.Web;
using System;
using System.Collections.Generic;
using Xunit;

namespace OnlineRetailPortal.Tests
{
    public class ProductControllerFixture
    {
        static IProductStoreFactory storeFactory;
        private IProductService _productService = new Services.ProductService(storeFactory);
        [Fact]
        public async void ToGetListOfProducts()
        {
            //Arrenge 
            int pageNo = 2;
            int pageSize = 1;
            ProductsController productsController = new ProductsController(_productService);
            GetProductsServiceRequest getProductsRequest = GetRequest(pageNo, pageSize);
            GetProductsResponse getProductsServiceResponse = GetExpectedResponse();


            //Act
            GetProductsResponse actualResponse = await productsController.GetProductsAsync(pageNo, pageSize);
            //var createdResult = product as Task<GetProductResponse>;

            //result
            //Assert.Equal("IPhone", product.Product.Id);
            Assert.Equal(1, actualResponse.PagingInfo.TotalPages);
            //Assert.AreEqual(values[1], "value2");

        }

        private GetProductsResponse GetExpectedResponse()
        {
            return new GetProductsResponse()
            {
                Products = new List<Web.Product>()
                {
                    new Web.Product()
                    {
                        SellerId = null,
                        Name = "Bottle",
                        Description = "Green Bottle",
                        HeroImage = "example.com",
                        // Price = new Web.Price { Amount = 99.99, IsNegotiable = true },
                        Category = "asdasd",
                        Images = new List<string>() { "ex.com" },
                        PurchasedDate = DateTime.Now,
                        PickupAddress = new Web.Address
                        {
                            Line1 = "ABC",
                            Line2 = "XYZ",
                            City = "Pune",
                            Pincode = 411001,
                            State = "Maharashtra"
                        }

                    }

                }
            };
        }

        private GetProductsServiceRequest GetRequest(int pageNo, int pageSize)
        {
            return new GetProductsServiceRequest()
            {
                PagingInfo = new Contracts.PagingInfo()
                {
                    PageNumber = pageNo,
                    PageSize = pageSize

                }

            };
        }
    }
}
