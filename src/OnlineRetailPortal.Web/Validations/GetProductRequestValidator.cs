using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.Results;
using FluentValidation;
using OnlineRetailPortal.Contracts;

namespace OnlineRetailPortal.Web
{
    public class GetProductRequestValidator : AbstractValidator<GetProductServiceRequest>
    {
        public  GetProductRequestValidator()
        {
            RuleFor(x => x.productId)
            .NotNull()
            .NotEmpty()
            .WithMessage("The Product ID cannot be blank.");

        }
    }
}