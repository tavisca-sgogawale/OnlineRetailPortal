using System;
using System.Collections.Generic;

namespace OnlineRetailPortal.Web
{
    public static class FilterTranslator
    {
        public static List<Contracts.Filter> ToEntity(this List<Filter> filters)
        {
            if (filters == null)
                return null;

            var filterList = new List<Contracts.Filter>();
            foreach (var filter in filters)
            {
                filterList.Add(filter.ToType());
            }
            return filterList;
        }

        public static Contracts.Filter ToType(this Web.Filter filter)
        {
            switch (filter.GetType().Name)
            {
                case "SearchFilter":
                    return new Contracts.SearchFilter() { Query = filter.GetType().GetProperty("Query").GetValue(filter, null).ToString() };
                case "PriceFilter":
                    return new Contracts.PriceFilter()
                    {
                        Max = int.Parse(filter.GetType().GetProperty("Max").GetValue(filter, null).ToString()),
                        Min = int.Parse(filter.GetType().GetProperty("Min").GetValue(filter, null).ToString())
                    };
                case "StatusFilter":
                    return new Contracts.StatusFilter() { Type = filter.GetType().GetProperty("Type").GetValue(filter, null).ToString() };
                case "IdFilter":
                    return new Contracts.IdFilter() { UserId = filter.GetType().GetProperty("UserId").GetValue(filter, null).ToString() };
            }
            throw new InvalidOperationException();
        }
    }
}
