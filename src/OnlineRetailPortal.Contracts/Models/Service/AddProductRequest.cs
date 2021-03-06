﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineRetailPortal.Contracts
{
    public class AddProductRequest
    {
        public string SellerId { get; set; }
        public string Id { get; set; }
        public string Name { get; set; }
        public Category Category { get; set; }
        public Price Price { get; set; }
        public string Description { get; set; }
        public Nullable<DateTime> PurchasedDate { get; set; }
        public string HeroImage { get; set; }
        public List<string> Images { get; set; }
        public Address PickupAddress { get; set; }
    }
}
