using FluentValidation.Results;
using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRetailPortal.Core
{
    public class Product
    {
        public string SellerId { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Image HeroImage { get; set; }
        public Price Price { get; set; }
        public Category Category { get; set; }
        public Status Status { get; set; }
        public DateTime PostDateTime { get; set; }
        public DateTime ExpirationDate { get; set; }

        public List<Image> Images { get; set; }
        public Nullable<DateTime> PurchasedDate { get; set; }
        public Address PickupAddress { get; set; }

        IProductStore productStore;

        public Product(string sellerId, string name, Price price)
        {
            this.SellerId = sellerId;
            this.Name = name;
            this.Price = price;

        }

        public async Task<Product> SaveAsync(IProductStore productStore)
        {           
            var entityPostRequest = this.ToEntity();
            
            var entityPostResponse = await productStore.AddProductAsync(entityPostRequest);
            
            var responseProduct = entityPostResponse.ToModel();

            return responseProduct;
        }
    }
}
