using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;

namespace OnlineRetailPortal.Web
{
    public class GetProductsRequestValidator : AbstractValidator<GetProductsServiceRequest>
    {
        public GetProductsRequestValidator()
        {
            RuleFor(x => x.PageNo)
            .NotNull()
            .NotEmpty()
            .WithMessage("The Page No cannot be blank.");

            RuleFor(x => x.PageSize)
            .NotNull()
            .NotEmpty()
            .WithMessage("The Page size cannot be blank.");

        }
    }
}
