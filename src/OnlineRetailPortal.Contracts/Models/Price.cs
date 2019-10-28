using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineRetailPortal.Contracts
{
    public class Price
    {
        public double Amount { get; set; }
        public bool isPriceNegotiable { get; set; }
        public Currency Currency { get; set; }
    }
}
