using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineRetailPortal.Services
{
    public static class PagingInfoTranslator
    {
        public static Core.PagingInfo ToEntity(this PagingInfo pagingInfo)
        {
            if (pagingInfo == null)
                return null;
            return new Core.PagingInfo()
            {
               PageNumber = pagingInfo.PageNumber,
               PageSize = pagingInfo.PageSize,
               TotalPages = pagingInfo.TotalPages
            };
        }

        public static PagingInfo ToModel(this Core.PagingInfo pagingInfo)
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
    }
}
