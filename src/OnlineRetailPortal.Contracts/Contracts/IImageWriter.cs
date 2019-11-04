using Microsoft.AspNetCore.Http;
using OnlineRetailPortal.Contracts.Models;
using System.Threading.Tasks;

namespace OnlineRetailPortal.Contracts.Contracts
{
    public interface IImageWriter
    {
        Task<ImageWriterResponse> WriteFile(IFormFile file);

    }
}
