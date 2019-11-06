using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineRetailPortal.Mock
{
    public static class AddressTranslator
    {
        public static Address ToModel(this Address pickupAddress)
        {
            if (pickupAddress == null)
                return null;
            return new Product().PickupAddress = new Address()
            {
                Line1 = pickupAddress.Line1,
                Line2 = pickupAddress.Line2,
                City = pickupAddress.City,
                Pincode = pickupAddress.Pincode,
                State = pickupAddress.State
            };
        }

        public static Address ToEntity(this Address pickupAddress)
        {
            if (pickupAddress == null)
                return null;
            return new Product().PickupAddress = new Address()
            {
                Line1 = pickupAddress.Line1,
                Line2 = pickupAddress.Line2,
                City = pickupAddress.City,
                Pincode = pickupAddress.Pincode,
                State = pickupAddress.State
            };
        }
    }
}
