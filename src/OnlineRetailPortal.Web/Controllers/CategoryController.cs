using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnlineRetailPortal.Contracts;
using OnlineRetailPortal.Web.Models;

namespace OnlineRetailPortal.Web
{
    [Route("api/v1.0/onlineretailportal")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        
        [Route("api/v1.0/onlineretailportal/categories")]
        [HttpGet("categories")]
        public async Task<ListOfCategory> GetCategories()
        { 
            var serviceResponse = await _categoryService.GetCategoriesAsync();
            var listOfCategories = serviceResponse.ToCategoriesContract();
            
            var response = CategoryResponse.CategoriesToString(listOfCategories);
            
            return response;


        }
    }
}