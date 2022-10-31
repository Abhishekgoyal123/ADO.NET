using WebApplication1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        IDbAccessService<Category, int> CategoryService;

        public CategoryController(IDbAccessService<Category, int> _CategoryService)
        {
            this.CategoryService = _CategoryService;
        }


        [HttpGet]

        public async Task<IActionResult> Get()
        {
            var result = await CategoryService.GetAsync();
            return Ok(result);
        }
    }
}
