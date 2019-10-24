using OnlineRetailPortal.Contracts.Contracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineRetailPortal.Contracts.Models
{
    public class ImageWriterSuccessResponse:IImageWriterResponse
    {
        public bool Success { get; set; }

        public string Response { get; set; }
    }
}
