using Moq;
using OnlineRetailPortal.Contracts;
using OnlineRetailPortal.Web;
using System;
using System.Threading.Tasks;
using Xunit;

namespace OnlineRetailPortal.Tests
{
    public class ProductControllerFixture
    {
        [Fact]
        public async void ToGetListOfProducts()
        {
            //Arrenge 
            var productServiceMock = new Mock<IProductService>();
            productServiceMock.Setup(service => service.GetProductAsync("12"))
                        .ReturnsAsync(new GetProductServiceResponse() { Product = new Contracts.Product() { Id = "12" , Name = "IPhone"} });

            //Act
            var controller = new ProductsController(productServiceMock.Object);
            var product = await controller.GetProductAsync("12");
            //var createdResult = product as Task<GetProductResponse>;

            //result
            Assert.Equal("IPhone",product.Product.Id);
            //Assert.AreEqual(values[0], "value1");
            //Assert.AreEqual(values[1], "value2");

        }
    }
}
