using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.Results;
using OnlineRetailPortal.Core;

namespace OnlineRetailPortal.Web
{
    public class GetProductsRequestValidator : AbstractValidator<GetProductsServiceRequest>
    {
        public GetProductsRequestValidator()
        {
            RuleFor(x => x.PagingInfo.PageNumber)
            .Cascade(CascadeMode.StopOnFirstFailure)
            .NotNull()
            .WithErrorCode(ErrorCode.NullField())
            .WithMessage(Error.NullField("Page Number"))
            .NotEmpty()
            .WithErrorCode(ErrorCode.MissingField())
            .WithMessage(Error.MissingField("Page Number"));

            RuleFor(x => x.PagingInfo.PageSize)
            .Cascade(CascadeMode.StopOnFirstFailure)
            .NotNull()
            .WithErrorCode(ErrorCode.NullField())
            .WithMessage(Error.NullField("Page Size"))
            .NotEmpty()
            .WithErrorCode(ErrorCode.MissingField())
            .WithMessage(Error.MissingField("Page Size"));

        }
    }
}
