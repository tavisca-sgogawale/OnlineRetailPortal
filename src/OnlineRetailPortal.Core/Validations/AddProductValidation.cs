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
            RuleFor(x => x.SellerId)
            .Cascade(CascadeMode.StopOnFirstFailure)
            .NotNull()
            .WithErrorCode(ErrorCode.NullField())
            .WithMessage(Error.NullField("Seller Id"))
            .NotEmpty()
            .WithErrorCode(ErrorCode.MissingField())
            .WithMessage(Error.MissingField("Seller Id"));

            RuleFor(x => x.Name)
            .Cascade(CascadeMode.StopOnFirstFailure)
            .NotNull()
            .WithErrorCode(ErrorCode.NullField())
            .WithMessage(Error.NullField("Name"))
            .NotEmpty()
            .WithErrorCode(ErrorCode.MissingField())
            .WithMessage(Error.MissingField("Name"))
            .Length(2, 20)
            .WithErrorCode(ErrorCode.GreaterCharacter())
            .WithMessage(Error.GreaterCharacter("Title", "2"));

            RuleFor(x => x.Price.Money.Amount)
            .Cascade(CascadeMode.StopOnFirstFailure)
            .NotEmpty()
            .WithErrorCode(ErrorCode.MissingField())
            .WithMessage(Error.MissingField("Price"))
            .GreaterThan(0)
            .WithErrorCode(ErrorCode.GreaterValue())
            .WithMessage(Error.GreaterValue("Price", "0"));

            RuleFor(product => product.Price.Money.Currency)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .Equal("INR")
                .WithErrorCode(ErrorCode.InvalidCurrency())
                .WithMessage(Error.InvalidCurrency("INR"));

            RuleFor(x => x.Category)
            .Cascade(CascadeMode.StopOnFirstFailure)
            .NotNull()
            .WithErrorCode(ErrorCode.NullField())
            .WithMessage(Error.NullField("Category"))
            .NotEmpty()
            .WithErrorCode(ErrorCode.MissingField())
            .WithMessage(Error.MissingField("Category"));

            RuleFor(x => x.Price.IsNegotiable)
            .NotEmpty()
            .WithErrorCode(ErrorCode.MissingField())
            .WithMessage(Error.MissingField("IsNegotiable"));

            RuleFor(x => x.Description)
            .Cascade(CascadeMode.StopOnFirstFailure)
            .NotNull()
            .WithErrorCode(ErrorCode.MissingField())
            .WithMessage(Error.NullField("Description"))
            .NotEmpty()
            .WithErrorCode(ErrorCode.MissingField())
            .WithMessage(Error.MissingField("Description"))
            .Length(4, 100)
            .WithErrorCode(ErrorCode.GreaterCharacter())
            .WithMessage(Error.GreaterCharacter("Description", "4"));

            RuleFor(x => x.PurchasedDate)
            .LessThan(DateTime.Today)
            .WithErrorCode(ErrorCode.GreaterDate())
            .WithMessage(Error.GreaterDate("PurchasedDate"));

            When(x => x.PickupAddress != null,
            () =>
            {
                RuleFor(x => x.PickupAddress.Line1)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .WithErrorCode(ErrorCode.NullField())
                .WithMessage(Error.NullField("Line1"))
                .NotEmpty()
                .WithErrorCode(ErrorCode.MissingField())
                .WithMessage(Error.MissingField("Line1"))
                .Length(2, 20)
                .WithErrorCode(ErrorCode.GreaterCharacter())
                .WithMessage(Error.GreaterCharacter("Line1", "2"));

                RuleFor(x => x.PickupAddress.City)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .WithErrorCode(ErrorCode.NullField())
                .WithMessage(Error.NullField("City"))
                .NotEmpty()
                .WithErrorCode(ErrorCode.MissingField())
                .WithMessage(Error.MissingField("City"));

                RuleFor(x => x.PickupAddress.State)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotNull()
                .WithErrorCode(ErrorCode.NullField())
                .WithMessage(Error.NullField("State"))
                .NotEmpty()
                .WithErrorCode(ErrorCode.MissingField())
                .WithMessage(Error.MissingField("State"));

                RuleFor(x => x.PickupAddress.Pincode)
                .Cascade(CascadeMode.StopOnFirstFailure)
                .NotEmpty()
                .WithErrorCode(ErrorCode.MissingField())
                .WithMessage(Error.MissingField("Pincode"));
            });
        }
    }

}
