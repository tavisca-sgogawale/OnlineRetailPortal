using OnlineRetailPortal.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineRetailPortal.Mock.Models
{
    public class MockProductStore : IProductStore
    {
        public Task<EntityPostResponse> PostProductAsync(EntityPostRequest entityPostRequest)
        {
            throw new NotImplementedException();
        }
    }
}
