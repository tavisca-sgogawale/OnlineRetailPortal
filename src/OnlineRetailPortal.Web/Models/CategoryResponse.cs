
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineRetailPortal.Web
{
    public class CategoryResponse 
    {
        public List<Category> Categories { get; set; }

        public static List<string> CategoriesToString(CategoryResponse listOfCategories)
        {
            List<string> response = new List<string>();
            if (listOfCategories==null)
            {
                return response;
            }
            foreach (Category categoryObject in listOfCategories.Categories)
            {
                response.Add(categoryObject.Name);
            }
            return response;

        }
      

    }
}
