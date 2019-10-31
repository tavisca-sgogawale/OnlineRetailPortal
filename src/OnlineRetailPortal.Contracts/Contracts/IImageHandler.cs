using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRetailPortal.Contracts.Contracts
{
    public interface IImageHandler
    {
        /// <summary>
        /// Takes an UploadImageRequest type object and tries to save the image in it
        /// </summary>
        /// <param name="request"></param>
        /// <returns></returns>
        Task<UploadImageResponse> UploadImage(UploadImageRequest request);
        /// <summary>
        /// Takes a DeleteImageRequest object containing the name of the file to delete from the temporary folder
        /// </summary>
        /// <param name="imageUrl"></param>
        void DeleteTempImage(DeleteImageRequest request);
    }
    
}
