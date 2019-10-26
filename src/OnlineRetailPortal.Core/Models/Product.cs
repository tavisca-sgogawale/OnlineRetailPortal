﻿using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRetailPortal.Core
{
    public class Product
    {
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
        public DateTime PurchasedDate { get; set; }
        public Address PickupAddress { get; set; }

        IProductStore productStore;

        public Product()
        {

        }

        public Product(IProductStore productStore)
        {
            this.productStore = productStore;
        }


        public async Task<Product> AddProduct(Product product)
        {
            EntityPostRequest entityPostRequest = product.ToEntityRequest();
            
            EntityPostResponse entityPostResponse = await productStore.AddProduct(entityPostRequest);
            
            Product responseProduct = entityPostResponse.ToProduct();

            return responseProduct;
        }
    }
}
