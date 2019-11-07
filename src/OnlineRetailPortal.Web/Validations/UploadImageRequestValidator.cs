using Microsoft.AspNetCore.Http;
using FluentValidation;
using OnlineRetailPortal.Core;
using OnlineRetailPortal.Web.Models;
using System.IO;

namespace OnlineRetailPortal.Web.Validations
{
    public class UploadImageRequestValidator : AbstractValidator<HttpRequest>
    {
        public UploadImageRequestValidator()
        {
            RuleFor(req => req)
           .NotNull()
           .WithErrorCode(StatusCodes.Status400BadRequest.ToString())
           .WithMessage(Error.MissingImage());



            RuleFor(req => req.Form)
            .NotNull()
            .WithErrorCode(StatusCodes.Status400BadRequest.ToString())
            .WithMessage(Error.MissingImage());



            RuleFor(req => req.Form.Files)
            .NotNull()
            .WithErrorCode(StatusCodes.Status400BadRequest.ToString())
            .WithMessage(Error.MissingImage());



            RuleFor(req => req.Form.Files[0])
            .NotNull()
            .WithErrorCode(StatusCodes.Status400BadRequest.ToString())
            .WithMessage(Error.MissingImage());



            RuleFor(req => req.Form.Files[0])
            .Must(file => IsSupportedImageFile(file))
            .WithErrorCode(StatusCodes.Status415UnsupportedMediaType.ToString())
            .WithMessage(Error.UnsupportedFileFormat());


        }


        private static bool IsSupportedImageFile(IFormFile file)
        {
            byte[] fileBytes;
            using (var ms = new MemoryStream())
            {
                file.CopyTo(ms);
                fileBytes = ms.ToArray();
            }

            return SupportedImageFormats.GetImageFormat(fileBytes) != SupportedImageFormats.ImageFormat.unknown;
        }


    }
    public class DeleteImageRequestValidator : AbstractValidator<string>
    {
        public DeleteImageRequestValidator()
        {
            RuleFor(id=>id)
            .Cascade(CascadeMode.StopOnFirstFailure)
            .NotNull()
            .WithErrorCode(StatusCodes.Status400BadRequest.ToString())
            .WithMessage("No image id was provided")
            .NotEmpty()
            .WithErrorCode(StatusCodes.Status400BadRequest.ToString())
            .WithMessage("No image id was provided");
        }
    }
}
