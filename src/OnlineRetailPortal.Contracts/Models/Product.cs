using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRetailPortal.Contracts.Models
{
    public class Product
    {
        public int Id { get; set; }
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


    }

}