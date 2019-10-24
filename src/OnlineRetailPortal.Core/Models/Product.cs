using OnlineRetailPortal.Contracts.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRetailPortal.Core.Models
{
    public class Product
    {
        public string Id { get; set; }
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
        public Status Status { get; set; }


        
        public static async Task<List<Product>> GetAllProducts(int pagenumber, int pagesize)
        {
            List<Product> products = new List<Product>();
            //products = idbInterface.getProducts(pagenumber,pagesize);// This data will be fetched from database
            if (products.Count == 0)
            {
                throw new Exception("No Products Available");
            }
            return products;
        }

        public static async Task<Product> GetProductById(string productId)
        {
            Product product = null;
            //product = idbInterface.getProduct(productId);// This data will be fetched from database
            if (product == null)
            {
                throw new Exception("Product Not Found");
            }
            return product;
        }
    }

}