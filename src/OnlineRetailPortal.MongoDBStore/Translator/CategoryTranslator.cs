using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineRetailPortal.MongoDBStore
{
    public static class CategoryTranslator
    {
        public static string ToEntity(this Category category)
        {
            /*
            switch (category)
            {
                case Category.Bike:
                    return "Bike";
                case Category.Book:
                    return "Book";
                case Category.Car:
                    return "Car";
                case Category.Electronic:
                    return "Electronic";
                case Category.Fashion:
                    return "Fashion";
                case Category.Furniture:
                    return "Furniture";
                case Category.Mobile:
                    return "Mobile";
                case Category.Other:
                    return "Other";
                case Category.Property:
                    return "Property";
            }
            throw new NotSupportedException(category + " is not supported");
            */
            return category.Name;
        }

        public static Category ToModel(this string category)
        {
            Category res = new Category() { Name = category };
            /*
            switch (category)
            {
                
                
                case "Bike":
                    return Category.Bike;
                case "Book":
                    return Category.Book;
                case "Car":
                    return Category.Car;
                case "Electronic":
                    return Category.Electronic;
                case "Fashion":
                    return Category.Fashion;
                case "Furniture":
                    return Category.Furniture;
                case "Mobile":
                    return Category.Mobile;
                case "Other":
                    return Category.Other;
                case "Property":
                    return Category.Property;
            }
            throw new NotSupportedException(category + " is not supported");
            */
            return res;
    }
    }
}
