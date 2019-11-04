using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using OnlineRetailPortal.Core;


namespace OnlineRetailPortal.Web.Validations
{
    public class AddProductRequestValidator : AbstractValidator<AddProductRequest>
    {
        public AddProductRequestValidator()
        {
            RuleFor(x => x.SellerId)
            .NotNull()
            .WithErrorCode(ErrorCodes.NullField())
            .WithMessage(Error.NullField("Seller Id"))
            .NotEmpty()
            .WithErrorCode(ErrorCodes.MissingField())
            .WithMessage(Error.MissingField("Seller Id"));

            RuleFor(x => x.Name)
            .NotNull()
            .WithErrorCode(ErrorCodes.NullField())
            .WithMessage(Error.NullField("Title"))
            .NotEmpty()
            .WithErrorCode(ErrorCodes.MissingField())
            .WithMessage(Error.MissingField("Title"))
            .Length(2, 20)
            .WithErrorCode(ErrorCodes.GreaterCharacter())
            .WithMessage(Error.GreaterCharacter("Title", "2"));

            //RuleFor(x => x.Category)
            //.NotNull()
            //.WithMessage(Error.NullField("Category"))
            //.NotEmpty()
            //.WithMessage(Error.MissingField("Category"));

            RuleFor(x => x.Price.Value.Amount)
            .NotEmpty()
            .WithErrorCode(ErrorCodes.MissingField())
            .WithMessage(Error.MissingField("Price"))
            .GreaterThan(0)
            .WithErrorCode(ErrorCodes.GreaterValue())
            .WithMessage(Error.GreaterValue("Price", "0"));

            RuleFor(x => x.Price.IsNegotiable)
            .NotEmpty()
            .WithErrorCode(ErrorCodes.MissingField())
            .WithMessage(Error.MissingField("IsNegotiable"));

            RuleFor(x => x.Description)
            .NotNull()
            .WithErrorCode(ErrorCodes.MissingField())
            .WithMessage(Error.NullField("Description"))
            .NotEmpty()
            .WithErrorCode(ErrorCodes.MissingField())
            .WithMessage(Error.MissingField("Description"))
            .Length(4, 100)
            .WithErrorCode(ErrorCodes.GreaterCharacter())
            .WithMessage(Error.GreaterCharacter("Description", "4"));

            // RuleFor(x => x.PurchasedDate)
            // .LessThan(DateTime.Today)
            // .WithMessage("You cannot enter a Purchased date in the future.");

            When(x => x.PickupAddress.Line1 != null &&
            x.PickupAddress.City != null && x.PickupAddress.Pincode > 0 && x.PickupAddress.State != null,
            () =>
            {
                RuleFor(x => x.PickupAddress.Line1)
                .NotNull()
                .WithErrorCode(ErrorCodes.NullField())
                .WithMessage(Error.NullField("Line1"))
                .NotEmpty()
                .WithErrorCode(ErrorCodes.MissingField())
                .WithMessage(Error.MissingField("Line1"))
                .Length(2, 20)
                .WithErrorCode(ErrorCodes.GreaterCharacter())
                .WithMessage(Error.GreaterCharacter("Line1", "2"));

                RuleFor(x => x.PickupAddress.City)
                .NotNull()
                .WithErrorCode(ErrorCodes.NullField())
                .WithMessage(Error.NullField("City"))
                .NotEmpty()
                .WithErrorCode(ErrorCodes.MissingField())
                .WithMessage(Error.MissingField("City"));

                RuleFor(x => x.PickupAddress.State)
                .NotNull()
                .WithErrorCode(ErrorCodes.NullField())
                .WithMessage(Error.NullField("State"))
                .NotEmpty()
                .WithErrorCode(ErrorCodes.MissingField())
                .WithMessage(Error.MissingField("State"));

                RuleFor(x => x.PickupAddress.Pincode)
                .NotEmpty()
                .WithErrorCode(ErrorCodes.MissingField())
                .WithMessage(Error.MissingField("Pincode"));
            });

        }
    }
}
