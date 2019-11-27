using FluentValidation;
using OnlineRetailPortal.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineRetailPortal.Web
{
    public class UpdateProductRequestValidator : AbstractValidator<Product>
    {
        public UpdateProductRequestValidator()
        {
            RuleFor(x => x.Name)
            .Cascade(CascadeMode.StopOnFirstFailure)
            .Length(2, 20)
            .WithErrorCode(ErrorCode.GreaterCharacter())
            .When(x => x.Name!= null)
            .WithMessage(Error.GreaterCharacter("Title", "2"));

            RuleFor(x => x.Category)
            .Cascade(CascadeMode.StopOnFirstFailure)
            .Must(category => validateCategory(category))
            .WithMessage("Unsupported Category")
            .When(x => x.Category != null);

            RuleFor(x => x.Status)
            .Cascade(CascadeMode.StopOnFirstFailure)
            .Must(status => validateStatus(status))
            .WithMessage("Unsupported status")
            .Length(2, 20)
            .WithErrorCode(ErrorCode.GreaterCharacter())
            .When(x => x.Status != null);

            RuleFor(x => x.Price.Amount)
            .Cascade(CascadeMode.StopOnFirstFailure)
            .NotEmpty()
            .WithErrorCode(ErrorCode.MissingField())
            .WithMessage(Error.MissingField("Price"))
            .GreaterThan(0)
            .WithErrorCode(ErrorCode.GreaterValue())
            .When(x => x.Price != null ? x.Price.Amount != 0 :false)
            .WithMessage(Error.GreaterValue("Price", "0"));

            RuleFor(x => x.Description)
            .Cascade(CascadeMode.StopOnFirstFailure)
            .NotEmpty()
            .WithErrorCode(ErrorCode.MissingField())
            .WithMessage(Error.MissingField("Description"))
            .Length(4, 100)
            .WithErrorCode(ErrorCode.GreaterCharacter())
            .When(x=>x.Description !=null)
            .WithMessage(Error.GreaterCharacter("Description", "4"));

            RuleFor(x => x.PurchasedDate)
            .LessThan(DateTime.Today)
            .WithErrorCode(ErrorCode.GreaterDate())
            .When(x=>x.PurchasedDate == new DateTime())
            .WithMessage(Error.GreaterDate("PurchasedDate"));

            When(x => x.PickupAddress != null && (x.PickupAddress.Line1 != null ||
            x.PickupAddress.City != null || x.PickupAddress.Pincode >=0 || x.PickupAddress.State != null),
            () =>
            {
                RuleFor(x => x.PickupAddress.Line1)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .Length(2, 20)
                .WithErrorCode(ErrorCode.GreaterCharacter())
                .WithMessage(Error.GreaterCharacter("Line1", "2"));

                RuleFor(x => x.PickupAddress.Pincode.ToString())
                .Cascade(CascadeMode.StopOnFirstFailure)
                .Must(x => x.Length == 6)
                .WithErrorCode(ErrorCode.PincodeLength())
                .When(x => x.PickupAddress.Pincode >= 0 );

            });

        }

        private bool validateStatus(string status)
        {
            switch (status)
            {
                case "Active":
                    return true;
                case "Disabled":
                    return true;
                case "Sold":
                    return true;
                default:
                    return false;
            }
        }

        private bool validateCategory(string category)
        {
            switch (category.ToLower())
            {
                case "bike":
                    return true;
                case "book":
                    return true;
                case "car":
                    return true;
                case "Electronic":
                    return true;
                case "fashion":
                    return true;
                case "furniture":
                    return true;
                case "mobile":
                    return true;
                case "other":
                    return true;
                case "property":
                    return true;
                default:
                    return false;
            }
        }
    }
}
