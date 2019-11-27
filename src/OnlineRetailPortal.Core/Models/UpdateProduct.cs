using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;


namespace OnlineRetailPortal.Core
{
    public class UpdateProduct
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public Price Price { get; set; }
        public string Category { get; set; }
        public string HeroImage { get; set; }
        public Address PickupAddress { get; set; }
        public List<string> Images { get; set; }
        public Nullable<DateTime> PostDateTime { get; set; }
        public Nullable<DateTime> PurchasedDate { get; set; }
        public string Description { get; set; }
        public Nullable<DateTime> ExpirationDate { get; set; }
        public string Status { get; set; }

        //public async Task<Product> UpdateAsync(IProductStore productStore)
        //{
        //    var updateProductEntity = this.ToStoreEntity();
        //    var updateProductResponse = await productStore.UpdateProductAsync(updateProductEntity);
        //    return updateProductResponse.ToStoreModel();
        //}
    }
}
