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
        public Image HeroImage { get; set; }
        public Address PickupAddress { get; set; }
        public List<Image> Images { get; set; }
        public DateTime PostDateTime { get; set; }
        public DateTime? PurchasedDate { get; set; }
        public string Description { get; set; }
        public DateTime ExpirationDate { get; set; }
        public Status Status { get; set; }

        private static IProductStore _productStore;

        public Product(Price price, string sellerId ,string name)
        {
            Price = price;
            SellerId = sellerId;
            Name = name;
        }
        public static async Task<ProductsWithPageInitiation>  GetProductsAsync(GetProductsServiceRequest serviceRequest, IProductStore productStore)
        {
            _productStore = productStore;
            var request = serviceRequest.ToProductStoreRequest();
            var response = await _productStore.GetProductsAsync(request);
            return response.ToProductsWithPageInitiation();
        }
       
        public static async Task<Product> GetProductAsync(string productId, IProductStore productStore)
        {
            _productStore = productStore;
            var response = await _productStore.GetProductAsync(productId);
            return response.ToGetProductServiceResponse();
        }
    }

        public async Task<Product> SaveAsync(IProductStore productStore)
        {           
            var addProductRequest = this.ToEntity();            
            var addProductResponse = await productStore.AddProductAsync(addProductRequest);            
            return addProductResponse.ToModel();
        }
    }
}
