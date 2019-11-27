using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineRetailPortal.Contracts
{
    public class UpdateProductEntity
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string HeroImage { get; set; }
        public Price Price { get; set; }
        public string Category { get; set; }
        public string Status { get; set; }
        public DateTime? PostDateTime { get; set; }
        public DateTime? ExpirationDate { get; set; }
        public List<string> Images { get; set; }
        public Nullable<DateTime> PurchasedDate { get; set; }
        public Address PickupAddress { get; set; }
    }
}
