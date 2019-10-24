using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRetailPortal.Mock.Models
{
    public class MockProductStore : IProductStore
    {
        List<Product> productList = new List<Product>();

        public async Task<EntityPostResponse> PostProductAsync(EntityPostRequest entityPostRequest)
        {
            Product product = entityPostRequest.ToProduct();

            product = await AddProduct(product);

            EntityPostResponse entityPostResponse = product.ToEntityResponse();

            return entityPostResponse;
        }

        async Task<Product> AddProduct(Product product)
        {
            product.Status = Status.Active;
            product.PostDateTime = DateTime.Now;
            product.ExpirationDate = DateTime.Now.AddDays(30);
            productList.Add(product);

            return productList.Where(n => n.Id == product.Id).First();
        }
    }
}
