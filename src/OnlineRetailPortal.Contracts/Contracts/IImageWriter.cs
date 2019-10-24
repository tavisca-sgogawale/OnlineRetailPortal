using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRetailPortal.Contracts.Contracts
{
    public interface IImageWriter
    {
        Task<IImageWriterResponse> UploadImage(IFormFile file);
    }
}
