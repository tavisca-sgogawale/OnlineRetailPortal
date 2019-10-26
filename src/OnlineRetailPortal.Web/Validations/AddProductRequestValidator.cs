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
            .NotEmpty() 
            .WithMessage("The Seller ID cannot be blank.");

            RuleFor(x => x.ProductId)
            .NotNull()
            .NotEmpty()
            .WithMessage("The Product ID  cannot be blank."); ;

            RuleFor(x => x.Name)
            .NotNull()
            .NotEmpty()
            .Length(2, 20)
            .WithMessage("The Title cannot be less than 2 characters and more than  20 characters.");

            RuleFor(x => x.Category)
            .NotNull()
            .NotEmpty()
            .WithMessage("The Categorye cannot be blank.");

            // RuleFor(x => x.Price.Amount)
            // .NotEmpty()
            // .GreaterThan(0)
            // .WithMessage("The Price cannot be less than 1 Rupees and more than  10000000 Rupees.");

            // RuleFor(x => x.Price.isPriceNegotiable)
            // .NotNull()
            //.NotEmpty()
            //.WithMessage("The IsNegotiable cannot be blank.");

            // RuleFor(x => x.Description)
            // .NotNull()
            // .NotEmpty().WithMessage("The Discription cannot be blank.")
            // .Length(4, 100).WithMessage("The Discription cannot be less than 4 characters and more than  100 characters.");

            // RuleFor(x => x.PurchasedDate)
            // .LessThan(DateTime.Today)
            // .WithMessage("You cannot enter a Purchased date in the future.");

            // When(x => x.PickupAddress.Line1 != null, () => {
            //     RuleFor(x => x.PickupAddress.Line1)
            //     .NotNull()
            //     .NotEmpty()
            //     .Length(2, 20)
            //     .WithMessage("The Line1 cannot be less than 2 characters and more than  20 characters.");

            //     RuleFor(x => x.PickupAddress.City)
            //     .NotNull()
            //     .NotEmpty()
            //     .WithMessage("The City cannot be blank.");

            //     RuleFor(x => x.PickupAddress.Pincode)
            //     .NotNull()
            //     .NotEmpty()
            //     .WithMessage("The Pincode cannot be blank.");
            // });
        }
    }
}
