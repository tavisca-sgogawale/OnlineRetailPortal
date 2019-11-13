using System;

namespace OnlineRetailPortal.Core
{
    public static class CategoryTranslator
    {
        public static Contracts.Category ToEntity(this Category category)
        {
            switch (category)
            {
                case Category.Bike:
                    return Contracts.Category.Bike;
                case Category.Book:
                    return Contracts.Category.Book;
                case Category.Car:
                    return Contracts.Category.Car;
                case Category.Electronic:
                    return Contracts.Category.Electronic;
                case Category.Fashion:
                    return Contracts.Category.Fashion;
                case Category.Furniture:
                    return Contracts.Category.Furniture;
                case Category.Mobile:
                    return Contracts.Category.Mobile;
                case Category.Other:
                    return Contracts.Category.Other;
                case Category.Property:
                    return Contracts.Category.Property;
            }
            throw new NotSupportedException(category + " is not supported");
        }

        public static Category ToModel(this Contracts.Category category)
        {
            switch (category)
            {
                case Contracts.Category.Bike:
                    return Category.Bike;
                case Contracts.Category.Book:
                    return Category.Book;
                case Contracts.Category.Car:
                    return Category.Car;
                case Contracts.Category.Electronic:
                    return Category.Electronic;
                case Contracts.Category.Fashion:
                    return Category.Fashion;
                case Contracts.Category.Furniture:
                    return Category.Furniture;
                case Contracts.Category.Mobile:
                    return Category.Mobile;
                case Contracts.Category.Other:
                    return Category.Other;
                case Contracts.Category.Property:
                    return Category.Property;
            }
            throw new NotSupportedException(category + " is not supported");
        }
    }
}
