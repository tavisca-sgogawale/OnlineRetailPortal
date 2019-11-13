using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineRetailPortal.Web
{
    public class MoveImagesRequest
    {
        public string HeroImageUrl { get; set; }
        public List<string> ImageUrls { get; set; }
    }
}
