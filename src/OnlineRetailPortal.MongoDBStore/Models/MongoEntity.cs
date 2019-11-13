using OnlineRetailPortal.Contracts;
using System;

namespace OnlineRetailPortal.MongoDBStore
{
    public class MongoEntity
    {
        public string Id { get; set; }
        public string SellerId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public StorePrice Price { get; set; }
        public string Category { get; set; }
        public Gallery Gallery { get; set; }
        public Nullable<DateTime> PurchasedDate { get; set; }
        public Address PickupAddress { get; set; }
        public string Status { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public DateTime UpdatedDate { get; set; }
    }
}
