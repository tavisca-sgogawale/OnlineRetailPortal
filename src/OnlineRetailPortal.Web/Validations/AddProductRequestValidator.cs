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
            RuleFor(x => x.UserId)
            .NotEmpty()
            .WithMessage("The User ID  cannot be blank.");

            RuleFor(x => x.Id)
            .NotEmpty()
            .WithMessage("The Product ID  cannot be blank."); ;

            RuleFor(x => x.Name)
            .NotEmpty()
            .Length(2, 20)
            .WithMessage("The Title cannot be less than 2 characters and more than  20 characters.");

            RuleFor(x => x.Category)
            .NotEmpty()
            .WithMessage("The Categorye cannot be blank.");

            RuleFor(x => x.Price.Amount)
            .NotEmpty()
            .InclusiveBetween(1, 10000000)
            .WithMessage("The Price cannot be less than 1 Rupees and more than  10000000 Rupees.");

            RuleFor(x => x.Price.isPriceNegotiable)
           .NotEmpty()
           .WithMessage("The IsNegotiable cannot be blank.");

            RuleFor(x => x.Description)
            .NotEmpty().WithMessage("The Discription cannot be blank.")
            .Length(4, 100).WithMessage("The Discription cannot be less than 4 characters and more than  100 characters.");

            RuleFor(x => x.PurchasedDate)
            .LessThan(DateTime.Today)
            .WithMessage("You cannot enter a Purchased date in the future.");

            When(x => x.PickupAddress.Line1 != null, () => {
                RuleFor(x => x.PickupAddress.Line1)
                .NotEmpty()
                .Length(2, 20)
                .WithMessage("The Line1 cannot be less than 2 characters and more than  20 characters.");

                RuleFor(x => x.PickupAddress.City)
                .NotEmpty()
                .WithMessage("The City cannot be blank.");

                RuleFor(x => x.PickupAddress.Pincode)
                .NotEmpty()
                .WithMessage("The Pincode cannot be blank.");
            });
        }
    }
}
