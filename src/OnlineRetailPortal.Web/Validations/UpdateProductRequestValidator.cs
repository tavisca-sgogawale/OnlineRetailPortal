using FluentValidation;
using OnlineRetailPortal.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineRetailPortal.Web
{
    public class UpdateProductRequestValidator : AbstractValidator<UpdateProductEntity>
    {
        public UpdateProductRequestValidator()
        {
            RuleFor(x => x.Id)
            .Cascade(CascadeMode.StopOnFirstFailure)
            .NotNull()
            .WithErrorCode(ErrorCode.NullField())
            .WithMessage(Error.NullField("Product Id"))
            .NotEmpty()
            .WithErrorCode(ErrorCode.MissingField())
            .WithMessage(Error.MissingField("Product Id"));

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

            RuleFor(x => x.Category)
            .Cascade(CascadeMode.StopOnFirstFailure)
            .NotNull()
            .WithErrorCode(ErrorCode.NullField())
            .WithMessage(Error.NullField("Category"))
            .NotEmpty()
            .WithErrorCode(ErrorCode.MissingField())
            .WithMessage(Error.MissingField("Category"));

            RuleFor(x => x.Price.Amount)
            .Cascade(CascadeMode.StopOnFirstFailure)
            .NotEmpty()
            .WithErrorCode(ErrorCode.MissingField())
            .WithMessage(Error.MissingField("Price"))
            .GreaterThan(0)
            .WithErrorCode(ErrorCode.GreaterValue())
            .WithMessage(Error.GreaterValue("Price", "0"));

            RuleFor(x => x.Price.IsNegotiable)
            .NotNull()
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

            When(x => x.PickupAddress != null && x.PickupAddress.Line1 != null &&
            x.PickupAddress.City != null && x.PickupAddress.Pincode > 0 && x.PickupAddress.State != null,
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
