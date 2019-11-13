
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
            
            if (listOfCategories==null)
            {
                return null;       
            }
            ListOfCategory response = new ListOfCategory();
            foreach (Category categoryObject in listOfCategories.Categories)
            {
                
                response.listOfCategory.Add(categoryObject.Name);
            }
            return response;

        }
      

    }
}
