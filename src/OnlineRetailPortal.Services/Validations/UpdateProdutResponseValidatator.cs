using OnlineRetailPortal.Contracts;
using OnlineRetailPortal.Core;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;

namespace OnlineRetailPortal.Services
{
    public static class UpdateProdutResponseValidatator
    {
        public static void EnsureValid(this Core.Product product , UpdateProductEntity updateProductEntity)
        {
            if (product == null)
            {
                throw new BaseException(Convert.ToInt32(ErrorCode.ProductNotFound()), Error.ProductNotFound(updateProductEntity.Id), null, HttpStatusCode.NotFound);
            }
        }
    }
}
