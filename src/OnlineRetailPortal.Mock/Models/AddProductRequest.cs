using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineRetailPortal.Mock
{
    public class AddProductRequest
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public Image HeroImage { get; set; }
        public Price Price { get; set; }
        public Category Category { get; set; }

        public List<Image> Images { get; set; }
        public DateTime PurchasedDate { get; set; }
        public Address PickupAddress { get; set; }
    }
}
