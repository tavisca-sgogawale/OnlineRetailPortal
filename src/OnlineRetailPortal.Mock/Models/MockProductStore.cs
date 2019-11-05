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
            new Product{SellerId="1",ProductId="101",Name="Mobile", Price=new Price{Money = new Money(200.0, "INR"), IsNegotiable=true}, Category=Category.Mobile,
                HeroImage =new Image{Url = "https://www.olx.in/item/11-pro-max-64-gb-full-box-iid-1540782056/gallery"},
                Description ="11 pro max 64 gb full box", Images=null,
                PickupAddress =new Address{Line1="abc",Line2="xyz", City="Pune",State="Maharashtra", Pincode=411038 },
                PostDateTime =  new DateTime(2019,12,1),ExpirationDate = new DateTime(2019,12,1).AddDays(30), PurchasedDate = DateTime.Now, Status = Status.Active },

            new Product{SellerId="2",ProductId="102",Name="Bottle", Price=new Price{ Money = new Money(200.0, "INR"), IsNegotiable=true}, Category=Category.Other,
                HeroImage =new Image{Url = "https://www.olx.in/item/11-pro-max-64-gb-full-box-iid-1540782056/gallery"},
                Description ="Tavisca green color bottle", Images=null,
                PickupAddress =new Address{Line1="abc",Line2="xyz", City="Pune",State="Maharashtra", Pincode=411038 },
                PostDateTime =  new DateTime(2019,12,1),ExpirationDate = new DateTime(2019,12,1).AddDays(30), PurchasedDate =  new DateTime(2019,12,1), Status = Status.Active },

             new Product{SellerId="3",ProductId="103",Name="Computer", Price=new Price{Money= new Money(200.0, "INR"), IsNegotiable=false}, Category=Category.Electronic,
                HeroImage =new Image{Url = "https://www.olx.in/item/11-pro-max-64-gb-full-box-iid-1540782056/gallery"},
                Description ="hp desktop", Images=null,
                PickupAddress =new Address{Line1="abc",Line2="xyz", City="Pune",State="Maharashtra", Pincode=411038 },
                PostDateTime =  new DateTime(2019,12,1),ExpirationDate = new DateTime(2019,12,1).AddDays(30), PurchasedDate = DateTime.Now, Status = Status.Active }
        };

        AddProductValidation validation;

        public MockProductStore()
        {
            validation = new AddProductValidation();
        }

        public async Task<AddProductStoreResponse> AddProductAsync(AddProductStoreRequest request)
        {
            var product = request.ToModel();

            validation.EnsureValidResult(request);

            product = await Task.Run(() => {

                var guid = Guid.NewGuid();
                product.ProductId = guid.ToString();
                product.Status = Status.Active;
                product.PostDateTime = DateTime.Now;
                product.ExpirationDate = DateTime.Now.AddDays(30);
                productList.Add(product);           

                return productList.Last();
            });

            var entityPostResponse = product.ToEntity();

            return entityPostResponse;
        }

        public async Task<GetProductStoreResponse> GetProductAsync(GetProductStoreRequest request)
        {
            Product response = await Task.Run(() => {
                try
                {
                    response = productList.Where(x => x.ProductId == request.ProductId).First();
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
                    List<Product> products = productList.Where(y => y.Status == Status.Active).OrderBy(x => x.Price.Money.Amount).Take(50).ToList();
                    response = products.ToGetProductsStoreResponse();
                    return response;
                }
            });

            return response;
        }

    }
}
