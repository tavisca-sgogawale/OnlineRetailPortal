using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineRetailPortal.Core.Models
{
    public class Price
    {
        public double Amount { get; set; }
        public bool isPriceNegotiable { get; set; }
        public Currency Currency { get; }
    }
}
