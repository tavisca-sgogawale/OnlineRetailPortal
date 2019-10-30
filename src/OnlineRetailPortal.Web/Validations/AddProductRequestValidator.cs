using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;


namespace OnlineRetailPortal.Web.Validations
{
    public class AddProductRequestValidator : AbstractValidator<AddProductRequest>
    {
        public AddProductRequestValidator()
        {
            RuleFor(x => x.SellerId)
            .Cascade(CascadeMode.StopOnFirstFailure)
            .NotNull()
            .WithMessage(ErrorMessages.NullField("Seller Id"))
            .NotEmpty()
            .WithMessage(ErrorMessages.MissingField("Seller Id"));

            RuleFor(x => x.Name)
            .NotNull()
            .WithMessage(ErrorMessages.NullField("Title"))
            .NotEmpty()
            .WithMessage(ErrorMessages.MissingField("Title"))
            .Length(2, 20)
            .WithMessage(ErrorMessages.Greater("Title", "2"));

            //RuleFor(x => x.Category)
            //.NotNull()
            //.WithMessage(ErrorMessages.NullField("Category"))
            //.NotEmpty()
            //.WithMessage(ErrorMessages.MissingField("Category"));

             RuleFor(x => x.Price.Amount)
            .NotNull()
            .WithMessage(ErrorMessages.NullField("Price"))
            .NotEmpty()
            .WithMessage(ErrorMessages.MissingField("Price"))
            .GreaterThan(0)
            .WithMessage(ErrorMessages.Greater("Price","0"));

            RuleFor(x => x.Price.IsNegotiable)
            .NotNull()
            .WithMessage(ErrorMessages.NullField("IsNegotiable"))
            .NotEmpty()
            .WithMessage(ErrorMessages.MissingField("IsNegotiable"));

            RuleFor(x => x.Description)
            .NotNull()
            .WithMessage(ErrorMessages.NullField("Description"))
            .NotEmpty()
            .WithMessage(ErrorMessages.MissingField("Description"))
            .Length(4, 100).WithMessage(ErrorMessages.Greater("Description", "4"));

            // RuleFor(x => x.PurchasedDate)
            // .LessThan(DateTime.Today)
            // .WithMessage("You cannot enter a Purchased date in the future.");

            When(x => x.PickupAddress.Line1 != null, () =>
            {
                RuleFor(x => x.PickupAddress.Line1)
                .NotNull()
                .WithMessage(ErrorMessages.NullField("Line1"))
                .NotEmpty()
                .WithMessage(ErrorMessages.MissingField("Line1"))
                .Length(2, 20)
                .WithMessage(ErrorMessages.Greater("Line1", "2"));

                RuleFor(x => x.PickupAddress.City)
                .NotNull()
                .WithMessage(ErrorMessages.NullField("City"))
                .NotEmpty()
                .WithMessage(ErrorMessages.MissingField("City"));

                RuleFor(x => x.PickupAddress.Pincode)
               .NotNull()
               .WithMessage(ErrorMessages.NullField("Pincode"))
               .NotEmpty()
               .WithMessage(ErrorMessages.MissingField("Pincode"));
            });
        }
    }
}
