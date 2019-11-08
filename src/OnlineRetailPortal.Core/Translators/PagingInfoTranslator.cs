using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineRetailPortal.Core
{
    public static class PagingInfoTranslator
    {
        public static PagingInfo ToModel(this Contracts.PagingInfo pagingInfo)
        {
            if (pagingInfo == null)
                return null;
            return new PagingInfo()
            {
               PageNumber = pagingInfo.PageNumber,
               PageSize = pagingInfo.PageSize,
               TotalPages = pagingInfo.TotalPages
            };
        }

        public static Contracts.PagingInfo ToEntity(this PagingInfo pagingInfo)
        {
            if (pagingInfo == null)
                return null;
            return new Contracts.PagingInfo()
            {
                PageNumber = pagingInfo.PageNumber,
                PageSize = pagingInfo.PageSize,
                TotalPages = pagingInfo.TotalPages
            };
        }
    }
}
