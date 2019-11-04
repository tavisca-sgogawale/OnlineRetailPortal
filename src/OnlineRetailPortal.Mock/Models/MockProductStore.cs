using FluentValidation.Results;
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
        List<Product> productList = new List<Product>() {
            new Product{Id="101",Name="Mobile", Price=new Price{Value = new Value(200.0, "INR"), IsNegotiable=true}, Category=Category.Mobiles,
                HeroImage =new Image{Url = "https://www.olx.in/item/11-pro-max-64-gb-full-box-iid-1540782056/gallery"},
                Description ="11 pro max 64 gb full box", Images=null,
                PickupAddress =new Address{Line1="abc",Line2="xyz", City="Pune",State="Maharashtra", Pincode=411038 },
                PostDateTime =  new DateTime(2019,12,1),ExpirationDate = new DateTime(2019,12,1).AddDays(30), PurchasedDate = DateTime.Now, Status = Status.Active },

            new Product{Id="102",Name="Bottle", Price=new Price{ Value = new Value(200.0, "INR"), IsNegotiable=true}, Category=Category.Others,
                HeroImage =new Image{Url = "https://www.olx.in/item/11-pro-max-64-gb-full-box-iid-1540782056/gallery"},
                Description ="Tavisca green color bottle", Images=null,
                PickupAddress =new Address{Line1="abc",Line2="xyz", City="Pune",State="Maharashtra", Pincode=411038 },
                PostDateTime =  new DateTime(2019,12,1),ExpirationDate = new DateTime(2019,12,1).AddDays(30), PurchasedDate =  new DateTime(2019,12,1), Status = Status.Active },

             new Product{Id="103",Name="Computer", Price=new Price{Value= new Value(200.0, "INR"), IsNegotiable=false}, Category=Category.Electronics,
                HeroImage =new Image{Url = "https://www.olx.in/item/11-pro-max-64-gb-full-box-iid-1540782056/gallery"},
                Description ="hp desktop", Images=null,
                PickupAddress =new Address{Line1="abc",Line2="xyz", City="Pune",State="Maharashtra", Pincode=411038 },
                PostDateTime =  new DateTime(2019,12,1),ExpirationDate = new DateTime(2019,12,1).AddDays(30), PurchasedDate = DateTime.Now, Status = Status.Active }
        };

        IAddProductValidation validation;

        public MockProductStore()
        {
            validation = new AddProductValidation();
        }

        public async Task<AddProductStoreResponse> AddProductAsync(AddProductStoreRequest request)
        {
            var product = request.ToProduct();

            validation.EnsureValidResult(request);

            product = await Task.Run(() => {

                var guid = Guid.NewGuid();
                product.Id = guid.ToString();
                product.Status = Status.Active;
                product.PostDateTime = DateTime.Now;
                product.ExpirationDate = DateTime.Now.AddDays(30);
                productList.Add(product);           

                return productList.Last();
            });

            var entityPostResponse = product.ToEntityResponse();

            return entityPostResponse;
        }

        public async Task<GetProductStoreResponse> GetProductAsync(GetProductStoreRequest request)
        {
            Product response = await Task.Run(() => {
                try
                {
                    response = productList.Where(x => x.Id == request.ProductId).First();
                    return response;
                }
                catch (Exception)
                {
                    return null;
                }
            });

            return response.ToGetProductStore();
        }

        public async Task<GetProductsStoreResponse> GetProductsAsync(GetProductsStoreRequest request)
        {
            GetProductsStoreResponse response = new GetProductsStoreResponse();

            response = await Task.Run(() =>
            {
                if (request.SortBy == 0)
                {
                    List<Product> products = productList.Where(y => y.Status == Status.Active).OrderBy(x => x.PostDateTime).Take(50).ToList();
                    response = products.ToGetProductsStoreResponse();
                    return response;
                }
                else
                {
                    List<Product> products = productList.Where(y => y.Status == Status.Active).OrderBy(x => x.Price.Value.Amount).Take(50).ToList();
                    response = products.ToGetProductsStoreResponse();
                    return response;
                }
            });

            return response;
        }

    }
}
