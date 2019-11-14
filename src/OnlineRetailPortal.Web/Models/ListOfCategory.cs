using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineRetailPortal.Web.Models
{
    public class ListOfCategory
    {
        public List<string> categories { get; set; }
        public ListOfCategory()
        {
            categories = new List<string>();
        }

     
    }
}
