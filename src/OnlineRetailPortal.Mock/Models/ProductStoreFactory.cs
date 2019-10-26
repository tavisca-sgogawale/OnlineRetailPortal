﻿using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineRetailPortal.Mock.Models
{
    class ProductStoreFactory : IProductStoreFactory
    {
        public IProductStore GetStoreType(string storeValue)
        {
            if(storeValue == "Mock")
            { 
                    return new MockProductStore();
            }
            return null;
        }
    }
}
