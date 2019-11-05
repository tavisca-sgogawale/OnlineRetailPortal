using FluentValidation;
using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace OnlineRetailPortal.Mock
{
    public class AddProductValidation : AbstractValidator<AddProductStoreRequest>, IAddProductValidation
    {
        public AddProductValidation()
        {
            RuleFor(product => product.Name).Must(IsNameValid);
            RuleFor(product => product.Description).Must(IsDescriptionValid);
            RuleFor(product => product.HeroImage.Url).Must(IsHeroImageValid);
            RuleFor(product => product.Price.Value.Amount).Must(IsPriceValid);
            RuleFor(product => product.Price.Value.Currency).Must(IsCurrencyValid);
            RuleFor(product => product.Category.ToString()).Must(IsCategoryValid);
            RuleFor(product => product.Images.Select(x => x.Url).ToList()).Must(IsImagesValid);
            RuleFor(product => product.PurchasedDate).Must(IsPurchaseDateValid);
            When(k => k.PickupAddress == null ,
            () =>
            {
                RuleFor(product => product.PickupAddress).Null();
            });
            When(k => k.PickupAddress != null,
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

        public bool IsCurrencyValid(string currency)
        {
            return currency == "INR";
        }
    }

    public class AddressValidator : AbstractValidator<Contracts.Address>
    {
        public AddressValidator()
        {
            RuleFor(address => address.Line1).NotEmpty().NotNull();
            RuleFor(address => address.Line2).NotEmpty().NotNull();
            RuleFor(address => address.Pincode).Must(IsPincodeValid);
            RuleFor(address => address.City).NotEmpty().NotNull();
            RuleFor(address => address.State).NotEmpty().NotNull();
        }

        public bool IsPincodeValid(int pincode)
        {
            return Regex.Match(pincode.ToString(), @"^[1-9][0-9]{5}$").Success;
        }
    }
}
