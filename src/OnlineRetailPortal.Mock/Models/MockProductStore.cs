using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRetailPortal.Mock
{
    public class MockProductStore : IProductStore
    {
        List<Product> productList = new List<Product>();

        public async Task<AddProductStoreResponse> AddProductAsync(AddProductStoreRequest entityPostRequest)
        {
            Product product = entityPostRequest.ToProduct();

            product = await Task.Run(() => {

                product.Status = Status.Active;
                product.PostDateTime = DateTime.Now;
                product.ExpirationDate = DateTime.Now.AddDays(30);
                productList.Add(product);           

                return productList.Where(n => n.Id == product.Id).First();
            });

            AddProductStoreResponse entityPostResponse = product.ToEntityResponse();

            return entityPostResponse;
        }
    }
}
