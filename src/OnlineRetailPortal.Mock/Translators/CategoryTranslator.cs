using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineRetailPortal.Mock
{
    public static class CategoryTranslator
    {
        public static Category ToModel(this Category category)
        {
            switch (category)
            {
                case Category.Bike:
                    return Category.Bike;
                case Category.Book:
                    return Category.Book;
                case Category.Car:
                    return Category.Car;
                case Category.Electronic:
                    return Category.Electronic;
                case Category.Fashion:
                    return Category.Fashion;
                case Category.Furniture:
                    return Category.Furniture;
                case Category.Mobile:
                    return Category.Mobile;
                case Category.Other:
                    return Category.Other;
                case Category.Property:
                    return Category.Property;
                default:
                    return Category.Other;
            }
        }

        public static Category ToEntity(this Category category)
        {
            switch (category)
            {
                case Category.Bike:
                    return Category.Bike;
                case Category.Book:
                    return Category.Book;
                case Category.Car:
                    return Category.Car;
                case Category.Electronic:
                    return Category.Electronic;
                case Category.Fashion:
                    return Category.Fashion;
                case Category.Furniture:
                    return Category.Furniture;
                case Category.Mobile:
                    return Category.Mobile;
                case Category.Other:
                    return Category.Other;
                case Category.Property:
                    return Category.Property;
                default:
                    return Category.Other;
            }
        }
    }
}
