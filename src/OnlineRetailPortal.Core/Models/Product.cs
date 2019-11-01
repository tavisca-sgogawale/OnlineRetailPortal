using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRetailPortal.Core
{
    public class Product
    {
        public string Id { get; set; }
        public string SellerId { get; set; }
        public string Name { get; set; }
        public Price Price { get; set; }
        
        public Category Category { get; set; }
        public Image HeroImage { get; set; }
        public Address PickupAddress { get; set; }
        public List<Image> Images { get; set; }
        public string UserId { get; set; }
        public DateTime PostDateTime { get; set; }
        public DateTime PurchasedDate { get; set; }
        public string Description { get; set; }
        public DateTime ExpirationDate { get; set; }

        public Status Status { get; set; }

        IProductStore productStore;

        public Product()
        {

        }

        public Product(IProductStore productStore)
        {
            this.productStore = productStore;
        }

        public async Task<GetProductsServiceResponse> GetProductsAsync(GetProductsServiceRequest serviceRequest)
        {
            var request = serviceRequest.ToProductStoreRequest();
            List<Product> products = new List<Product>();
            GetProductsStoreResponse response = new GetProductsStoreResponse();
            response = await productStore.GetProductsAsync(request);

            if (products.Count == 0)
            {
               throw new Exception("No Products Available");
            }
            return products.ToProductsList();
        }
       

        public async Task<GetProductServiceResponse> GetProductAsync(string productId)
        {
            Product product = new Product();
            GetProductStoreResponse response = new GetProductStoreResponse();
            response = await productStore.GetProductAsync(productId);
            //product   = idbInterface.getProduct(productId);// This data will be fetched from database
            if (response == null)
            {
                throw new Exception("Product Not Found");
            }
            return response.ToGetProductServiceResponse();
        }
    }

}