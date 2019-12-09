using System.Collections.Generic;
using System.Linq;

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

                if (filter is SearchFilter searchFilter)
                {
                    if (filterList.Where(i => i.GetType().Name == "SearchFilter").Count() == 0)
                        filterList.Add(searchFilter.ToEntity());
                }
                else if (filter is PriceFilter priceFilter)
                {
                    if (filterList.Where(i => i.GetType().Name == "PriceFilter").Count() == 0)
                        filterList.Add(priceFilter.ToEntity());
                }

                else if (filter is StatusFilter statusFilter)
                {
                    if (filterList.Where(i => i.GetType().Name == "StatusFilter").Count() == 0)
                        filterList.Add(statusFilter.ToEntity());
                }

                else if (filter is IdFilter idFilter)
                {
                    if (filterList.Where(i => i.GetType().Name == "IdFilter").Count() == 0)
                        filterList.Add(idFilter.ToEntity());
                }
                else if (filter is CategoryFilter categoryFilter)
                {
                    if (filterList.Where(i => i.GetType().Name == "CategoryFilter").Count() == 0)
                        filterList.Add(categoryFilter.ToEntity());
                }
            }
            return filterList;
        }

        public static Contracts.SearchFilter ToEntity(this SearchFilter filter)
        {
            Contracts.SearchFilter searchFilter = new Contracts.SearchFilter()
            {
                Name = "SearchFilter",
                Query = filter.Query
            };
            return searchFilter;
        }

        public static Contracts.PriceFilter ToEntity(this PriceFilter filter)
        {
            Contracts.PriceFilter priceFilter = new Contracts.PriceFilter()
            {
                Name = "PriceFilter",
                Min = filter.Min,
                Max = filter.Max
            };
            return priceFilter;
        }

        public static Contracts.StatusFilter ToEntity(this StatusFilter filter)
        {
            Contracts.StatusFilter statusFilter = new Contracts.StatusFilter()
            {
                Name = "StatusFilter",
                Type = filter.Type
            };
            return statusFilter;
        }

        public static Contracts.IdFilter ToEntity(this IdFilter filter)
        {
            Contracts.IdFilter idFilter = new Contracts.IdFilter()
            {
                Name = "IdFilter",
                UserId = filter.UserId
            };
            return idFilter;
        }

        public static Contracts.CategoryFilter ToEntity(this CategoryFilter filter)
        {
            Contracts.CategoryFilter categoryFilter = new Contracts.CategoryFilter()
            {
                Name = "CategoryFilter",
                Categories = filter.Categories
            };
            return categoryFilter;
        }
    }
}
