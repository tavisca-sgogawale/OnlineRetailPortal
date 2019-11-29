﻿using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRetailPortal.Mock
{
    public class MockProductStore : IProductStore
    {
        static List<Product> productList = new List<Product>() {
            new Product{SellerId="1",Id="101",Name="Mobile", Price=new Price{Money = new Money(13400.0, "INR"), IsNegotiable=true}, Category=new Contracts.Category(){Name="Mobile" },
                HeroImage = "https://www.olx.in/item/11-pro-max-64-gb-full-box-iid-1540782056/gallery",
                Description ="11 pro max 64 gb full box", Images= new List<string>(){"https://www.olx.in/item/11-pro-max-64-gb-full-box-iid-1540782056/gallery","https://www.olx.in/item/11-pro-max-64-gb-full-box-iid-1540782056/gallery" },
                PickupAddress =new Address{Line1="abc",Line2="xyz", City="Pune",State="Maharashtra", Pincode=411038 },
                PostDateTime =  new DateTime(2019,1,1),ExpirationDate = new DateTime(2019,12,1).AddDays(30), PurchasedDate = DateTime.Now, Status = Status.Active },

            new Product{SellerId="2",Id="102",Name="Bottle", Price=new Price{ Money = new Money(14400.0, "INR"), IsNegotiable=true}, Category=new Contracts.Category(){Name="Other" },
                HeroImage = "https://www.olx.in/item/11-pro-max-64-gb-full-box-iid-1540782056/gallery",
                Description ="Tavisca green color bottle", Images=null,
                PickupAddress =new Address{Line1="abc",Line2="xyz", City="Pune",State="Maharashtra", Pincode=411038 },
                PostDateTime =  new DateTime(2018,12,1),ExpirationDate = new DateTime(2019,12,1).AddDays(30), PurchasedDate =  new DateTime(2019,12,1), Status = Status.Active },

             new Product{SellerId="3",Id="103",Name="Computer", Price=new Price{Money= new Money(15500.0, "INR"), IsNegotiable=false}, Category=new Contracts.Category(){Name="Electronic" },
                HeroImage = "https://www.olx.in/item/11-pro-max-64-gb-full-box-iid-1540782056/gallery",
                Description ="hp desktop", Images=null,
                PickupAddress =new Address{Line1="abc",Line2="xyz", City="Pune",State="Maharashtra", Pincode=411038 },
                PostDateTime =  new DateTime(2011,12,1),ExpirationDate = new DateTime(2019,12,1).AddDays(30), PurchasedDate = DateTime.Now, Status = Status.Active }
        };

        public MockProductStore()
        {
        }

        public async Task<ProductEntity> AddProductAsync(ProductEntity request)
        {
            var product = request.ToModel();
            product.Id = Guid.NewGuid().ToString();
            product.Status = Status.Active;
            product.PostDateTime = DateTime.Now;
            product.ExpirationDate = DateTime.Now.AddDays(30);
            productList.Add(product);
            return product.ToEntity();
        }

        public async Task<GetProductStoreResponse> GetProductAsync(string productId)
        {
            Product response = productList.Where(x => x.Id == productId).First();
            return response.ToGetProductStore();
        }

        public async Task<GetProductsStoreResponse> GetProductsAsync(GetProductsStoreEntity request)
        {
            productList.Apply(request.Filters);
            var products = productList.Apply(request.ProductSort);

            int startIndex = (request.PagingInfo.PageNumber - 1) * (request.PagingInfo.PageSize);
            int endIndex = startIndex + request.PagingInfo.PageSize - 1;
            List<ProductEntity> responseProducts = new List<ProductEntity>();
            for (int currentIndex = startIndex; currentIndex <= endIndex; currentIndex++)
            {
                if (currentIndex == products.Count() || currentIndex > products.Count())
                    break;
                responseProducts.Add(products[currentIndex].ToEntity());
            }

            request.PagingInfo.TotalPages = (productList.Count() >= request.PagingInfo.PageSize) ? ((productList.Count() / request.PagingInfo.PageSize) + (productList.Count() % request.PagingInfo.PageSize)) : 1;
            var response = responseProducts.ToGetProductsStoreResponse(request.PagingInfo);
            return response;
        }

        public Task<ProductEntity> UpdateProductAsync(ProductEntity request)
        {
            throw new NotImplementedException();
        }
    }
}
