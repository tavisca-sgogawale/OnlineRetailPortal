using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRetailPortal.Contracts
{
    public interface IProductStore
    {
        Task<EntityPostResponse> PostProductAsync(EntityPostRequest entityPostRequest);
    }
}
