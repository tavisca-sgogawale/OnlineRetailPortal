﻿using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineRetailPortal.Contracts
{
    public interface IProductStoreFactory
    {
        IProductStore GetStoreType(string storeValue);
    }
}
