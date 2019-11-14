
using OnlineRetailPortal.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineRetailPortal.Web
{
    public class CategoryResponse 
    {
        
        public List<Category> Categories { get; set; }

        public static ListOfCategory CategoriesToString(CategoryResponse listOfCategories)
        {
            ListOfCategory response = new ListOfCategory();
            if (listOfCategories==null)
            {
                return response;       
            }
            //ListOfCategory response = new ListOfCategory();
            foreach (Category categoryObject in listOfCategories.Categories)
            {
                
                response.categories.Add(categoryObject.Name);
            }
            return response;

        }
      

    }
}
