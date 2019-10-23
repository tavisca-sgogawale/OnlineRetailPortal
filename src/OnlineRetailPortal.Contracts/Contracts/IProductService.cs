﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRetailPortal.Contracts
{
    public interface IProductService
    {
        Task<GetProductResponse> GetProductAsync(string productId);       
        Task<AddProductResponse> AddProductAsync(AddProductRequest addProductRequest);
    }
}
