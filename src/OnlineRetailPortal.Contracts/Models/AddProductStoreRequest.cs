using System;
using System.Collections.Generic;

namespace OnlineRetailPortal.Contracts
{
    public class AddProductStoreRequest
    {
        public string Id { get; set; }
        public string SellerId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Image HeroImage { get; set; }
        public Price Price { get; set; }
        public Category Category { get; set; }

        public List<Image> Images { get; set; }
        public Nullable<DateTime> PurchasedDate { get; set; }
        public Address PickupAddress { get; set; }
    }
}
