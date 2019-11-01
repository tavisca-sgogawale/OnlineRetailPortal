using FluentValidation;
using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace OnlineRetailPortal.Core
{
    public class AddProductValidation : AbstractValidator<Product>, IAddProductValidation
    {
        public AddProductValidation()
        {
            RuleFor(product => product.Name).Must(IsNameValid);
            RuleFor(product => product.Description).Must(IsDescriptionValid);
            RuleFor(product => product.HeroImage.Url).Must(IsHeroImageValid);
            RuleFor(product => product.Price.Value.Amount).Must(IsPriceValid);
            RuleFor(product => product.Category.ToString()).Must(IsCategoryValid);
            RuleFor(product => product.Images.Select(x=>x.Url).ToList()).Must(IsImagesValid);
            RuleFor(product => product.PurchasedDate).Must(IsPurchaseDateValid);
            When(k=>k.PickupAddress.Line1 == null || k.PickupAddress.Line2 == null ||
            k.PickupAddress.City == null || k.PickupAddress.Pincode <= 0 || k.PickupAddress.State == null,
            () =>
            {
                RuleFor(product => product.PickupAddress.Line1).Null();
                RuleFor(product => product.PickupAddress.Line2).Null();
                RuleFor(product => product.PickupAddress.City).Null();
                RuleFor(product => product.PickupAddress.Pincode).Equals(0);
                RuleFor(product => product.PickupAddress.State).Null();
            });
            When(k => k.PickupAddress.Line1 != null && k.PickupAddress.Line2 != null &&
            k.PickupAddress.City != null && k.PickupAddress.Pincode > 0 && k.PickupAddress.State != null,
            () =>
            {
                RuleFor(product => product.PickupAddress).SetValidator(new AddressValidator());
            });
        }

        public bool IsNameValid(string name)
        {
            return !string.IsNullOrEmpty(name);
        }

        public bool IsDescriptionValid(string description)
        {
            return !string.IsNullOrEmpty(description);
        }

        public bool IsHeroImageValid(string url)
        {
            return !string.IsNullOrEmpty(url);
        }

        public bool IsPriceValid(double price)
        {
            return (price > 0);
        }

        public bool IsCategoryValid(string category)
        {
            return !string.IsNullOrEmpty(category);
        }

        public bool IsImagesValid(List<string> urls)
        {
            return urls.Count >= 0;
        }

        public bool IsPurchaseDateValid(DateTime? date)
        {
            return date == null || date != null;
        }

    }

    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(address => address.Line1).Must(IsAddressValid);
            RuleFor(address => address.Line2).Must(IsAddressValid);
            RuleFor(address => address.Pincode).Must(IsPincodeValid);
        }

        public bool IsAddressValid(string line)
        {
            return !string.IsNullOrEmpty(line);
        }

        public bool IsPincodeValid(int pincode)
        {
            return Regex.Match(pincode.ToString(), @"^[1-9][0-9]{5}$").Success;
        }
    }
}
