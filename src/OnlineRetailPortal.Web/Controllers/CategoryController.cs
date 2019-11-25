using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OnlineRetailPortal.Contracts;
using OnlineRetailPortal.Web.Models;

namespace OnlineRetailPortal.Web.Controllers
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
       
        [HttpGet("categories")]
        public async Task<CategoryResponse> Get()        
        {
            var response = await _categoryService.GetCategoriesAsync();
            return response.ToModel();
        }

    }
}
