using FluentValidation;
using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace OnlineRetailPortal.Core
{
    public class AddProductValidation : AbstractValidator<Product>
    {
        public AddProductValidation()
        {
            RuleFor(product => product.Name).NotEmpty().NotNull();
            RuleFor(product => product.Description).NotEmpty().NotNull();
            RuleFor(product => product.HeroImage.Url).NotEmpty().NotNull();
            RuleFor(product => product.Price.Value.Amount).Must(IsPriceValid);
            RuleFor(product => product.Price.Value.Currency).Must(IsCurrencyValid);
            RuleFor(product => product.Category.ToString()).NotEmpty().NotNull();
            RuleFor(product => product.Images.Select(x=>x.Url).ToList()).Must(IsImagesValid);
            When(k=>k.PickupAddress == null,
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

        public bool IsPriceValid(double price)
        {
            return (price > 0);
        }

        public bool IsImagesValid(List<string> urls)
        {
            return urls.Count >= 0;
        }

        public bool IsCurrencyValid(string currency)
        {
            return currency == "INR";
        }
    }

    public class AddressValidator : AbstractValidator<Address>
    {
        public AddressValidator()
        {
            RuleFor(address => address.Line1).NotEmpty().NotNull();
            RuleFor(address => address.Line2).NotEmpty().NotNull();
            RuleFor(address => address.Pincode).Must(IsPincodeValid);
            RuleFor(address => address.State).NotEmpty().NotNull();
            RuleFor(address => address.City).NotEmpty().NotNull();
        }

        public bool IsPincodeValid(int pincode)
        {
            return Regex.Match(pincode.ToString(), @"^[1-9][0-9]{5}$").Success;
        }
    }
}
