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
        public string ProductId { get; set; }
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
        AddProductValidation validation;

        public Product(string sellerId, string name, Price price)
        {
            this.SellerId = sellerId;
            this.Name = name;
            this.Price = price;

            validation = new AddProductValidation();
        }

        public Product(IProductStore productStore, string sellerId, string name, Price price)
        {
            this.SellerId = sellerId;
            this.Name = name;
            this.Price = price;

            this.productStore = productStore;
            validation = new AddProductValidation();
        }


        public async Task<Product> AddProductAsync(Product product)
        {
            validation.EnsureValidResult(product);
           
            var entityPostRequest = product.ToEntityRequest();
            
            var entityPostResponse = await productStore.AddProductAsync(entityPostRequest);
            
            var responseProduct = entityPostResponse.ToProduct();

            return responseProduct;
        }
    }
}
