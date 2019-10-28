using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineRetailPortal.Contracts
{

        public class ProductList
        {
            public string Id { get; set; }
            public string Name { get; set; }
            public Price Price { get; set; }
            public Price Currency { get; set; }
            public Category Category { get; set; }
            public Image HeroImage { get; set; }
            public Address PickupAddress { get; set; }
            public DateTime PostDateTime { get; set; }
            public Status Status { get; set; }
        }
}
