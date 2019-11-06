using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.Results;
using FluentValidation;
using OnlineRetailPortal.Core;

namespace OnlineRetailPortal.Web
{
    public class GetProductRequestValidator : AbstractValidator<string>
    {
        public  GetProductRequestValidator()
        {
            RuleFor(id => id)
            .Cascade(CascadeMode.StopOnFirstFailure)
            .NotNull()
            .WithErrorCode(ErrorCode.NullField())
            .WithMessage(Error.NullField("Product Id"))
            .NotEmpty()
            .WithErrorCode(ErrorCode.MissingField())
            .WithMessage(Error.MissingField("Product Id"))
            .Length(2, 20)
            .WithErrorCode(ErrorCode.GreaterCharacter())
            .WithMessage(Error.GreaterCharacter("Product Id", "2"));

        }
    }
}