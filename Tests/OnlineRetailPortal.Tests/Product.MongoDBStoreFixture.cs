using OnlineRetailPortal.Contracts;
using OnlineRetailPortal.MongoDBStore;
using System.Threading.Tasks;
using Xunit;

namespace OnlineRetailPortal.Tests
{
    public class ProductStoreFixture
    {
        [Fact]
        public async Task Get_All_Products_Should_Return_List_Of_All_Products()
        {
            ProductStore productStore = new ProductStore();
            var pagingInfo = new PagingInfo() { PageNumber = 1, PageSize = 10, TotalPages = 100 };
            GetProductsEntity getProductsStoreRequest = new GetProductsEntity()
            {
                PagingInfo = pagingInfo
            };

            var productList = await productStore.GetProductsAsync(getProductsStoreRequest);

            Assert.Equal(2, productList.Products.Count);
        }
    }
}
