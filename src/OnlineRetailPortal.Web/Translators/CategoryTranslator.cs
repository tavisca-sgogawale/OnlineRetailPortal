using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineRetailPortal.Web
{
    public static class CategoryTranslator
    {
        public static Contracts.Category ToEntity(this string category)
        {
            /*
            switch (category)
            {
                case "Bike":
                    return Contracts.Category.Bike;
                case "Book":
                    return Contracts.Category.Book;
                case "Car":
                    return Contracts.Category.Car;
                case "Electronic":
                    return Contracts.Category.Electronic;
                case "Fashion":
                    return Contracts.Category.Fashion;
                case "Furniture":
                    return Contracts.Category.Furniture;
                case "Mobile":
                    return Contracts.Category.Mobile;
                case "Other":
                    return Contracts.Category.Other;
                case "Property":
                    return Contracts.Category.Property;
            }

            throw new NotSupportedException(category + " is not supported");
            */
            Contracts.Category contractsCategory = new Contracts.Category();
            contractsCategory.Name = category;
            return contractsCategory;
        }

        public static string ToModel(this Contracts.Category category)
        {
            /*
            switch (category)
            {
                case Contracts.Category.Bike:
                    return "Bike";
                case Contracts.Category.Book:
                    return "Book";
                case Contracts.Category.Car:
                    return "Car";
                case Contracts.Category.Electronic:
                    return "Electronic";
                case Contracts.Category.Fashion:
                    return "Fashion";
                case Contracts.Category.Furniture:
                    return "Furniture";
                case Contracts.Category.Mobile:
                    return "Mobile";
                case Contracts.Category.Other:
                    return "Other";
                case Contracts.Category.Property:
                    return "Property";
            }
            throw new NotSupportedException(category + " is not supported");
            */
            return category.Name;
        }
    }
}
