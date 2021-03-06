﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineRetailPortal.Web
{
    public class AddProductRequest
    {
        public string SellerId { get; set; }
        public string Name { get; set; }
        public string Category { get; set; }
        public Price Price { get; set; }
        public string Description { get; set; }
        public DateTime? PurchasedDate { get; set; }
        public string HeroImage { get; set; }
        public List<string> Images { get; set; }
        public Address PickupAddress { get; set; }
    }
}
