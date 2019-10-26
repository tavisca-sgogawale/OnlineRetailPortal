using System;
using System.Collections.Generic;
using System.Text;
using FluentValidation;

namespace OnlineRetailPortal.Contracts
{
    public interface IAddProductValidation : IValidator
    {
        bool IsNameValid(string name);
        bool IsDescriptionValid(string description);
        bool IsHeroImageValid(string url);
        bool IsPriceValid(double price);
        bool IsCategoryValid(string category);
        bool IsImagesValid(List<string> urls);
        bool IsPurchaseDateValid(DateTime? date);
    }
}
