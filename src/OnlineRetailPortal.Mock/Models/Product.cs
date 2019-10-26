using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineRetailPortal.Mock
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
        public Nullable<DateTime> PurchasedDate { get; set; }
        public Address PickupAddress { get; set; }
    }
}
