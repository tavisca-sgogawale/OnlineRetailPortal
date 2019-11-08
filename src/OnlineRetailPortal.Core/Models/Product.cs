using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace OnlineRetailPortal.Core
{
    public class Product
    {
        public string SellerId { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public Price Price { get; set; }
        public Category Category { get; set; }
        public string HeroImage { get; set; }
        public Address PickupAddress { get; set; }
        public List<string> Images { get; set; }
        public DateTime PostDateTime { get; set; }
        public DateTime? PurchasedDate { get; set; }
        public string Description { get; set; }
        public DateTime ExpirationDate { get; set; }
        public Status Status { get; set; }

        public Product(Price price, string sellerId, string name)
        {
            Price = price;
            SellerId = sellerId;
            Name = name;
        }
        public static async Task<ProductsWithPageInitiation> GetProductsAsync(GetProductsServiceRequest serviceRequest, IProductStore productStore)
        {
            var getProductsRequest = serviceRequest.ToEntity();
            var getProductsResponse = await productStore.GetProductsAsync(getProductsRequest);
            return getProductsResponse.ToModel();
        }

        public static async Task<Product> GetAsync(string productId, IProductStore productStore)
        {
            var getProductResponse = await productStore.GetProductAsync(productId);
            return getProductResponse.ToModel();
        }

        public async Task<Product> SaveAsync(IProductStore productStore)
        {
            var addProductRequest = this.ToEntity();
            var addProductResponse = await productStore.AddProductAsync(addProductRequest);
            return addProductResponse.ToModel();
        }
    }
}
