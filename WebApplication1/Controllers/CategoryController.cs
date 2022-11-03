using WebApplication1.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]/[action]")]
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

        [HttpGet]
        [ActionName("123")]
        public async Task<IActionResult> Get_1()
        {
            var result = await CategoryService.GetAsync();
            return Ok(result);
        }

        [HttpPost]

        public async Task<IActionResult> Delete(int id)
        {
            var result = await CategoryService.DeleteAsync(id);
            return Ok(result);
        }

        [Route("api_1/[controller]")]

        [HttpPost]

        public async Task<IActionResult> Create(Category category)
        {
            var result = await CategoryService.CreateAsync(category);
            return Ok(result);
        }

        [HttpPost]
        [ActionName("abc")]

        public async Task<IActionResult> Create1(Category category)
        {
            var result = await CategoryService.CreateAsync(category);
            return Ok(result);
        }

        //[HttpPost]
        //[ActionName("assignment")]
        //public async Task<Product> Search(string CategoryName, string ProductName)
        //{
        //    eShoppingCodiContext context = new eShoppingCodiContext();
        //    Category c1 = new Category();
        //    c1.CategoryName = CategoryName;
        //    Product P1 = new Product();
        //    P1.ProductName = ProductName;

        //    var record = await context.Categories.FindAsync(CategoryName);
        //    var record_1 = await context.Products.FindAsync(ProductName);

        //    var abc = from cat in context.Categories
        //              join prod in context.Products on cat.CategoryId equals prod. 
                      
        //              select cat;
        //    if(record != null && record_1 != null)
        //        return record_1;
        //      else
        //        return
            
            
        //}
    }
}
