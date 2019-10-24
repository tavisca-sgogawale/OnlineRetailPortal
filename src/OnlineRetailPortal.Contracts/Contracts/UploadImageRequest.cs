using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineRetailPortal.Contracts.Contracts
{
    public class UploadImageRequest
    {
        public IFormFile File { get; set; }
    }
}
