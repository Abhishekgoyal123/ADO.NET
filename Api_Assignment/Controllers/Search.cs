using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Api_Assignment.Models;
using Api_Assignment;

namespace Api_Assignment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Search : ControllerBase
    {

        eShoppingCodiContext context;

        public Search(eShoppingCodiContext context)
        {
            this.context = context;
        }
        [HttpGet]
        public  IActionResult abcd(string CategoryName, string ProductName)
        {
            //eShoppingCodiContext context = new eShoppingCodiContext();

            // eShoppingCodiContext context = new eShoppingCodiContext();
            //Category c1 = new Category();
            //c1.CategoryName = CategoryName;
            //Product P1 = new Product();
            //P1.ProductName = ProductName;

            //var record = await context.Categories.FindAsync(CategoryName);
            //var record_1 = await context.Products.FindAsync(ProductName);


            var abc = (from prod in context.Products
                       join subcat in context.SubCategories on prod.SubCategoryId equals subcat.SubCategoryId
                       join cat in context.Categories on subcat.CategoryId equals cat.CategoryId
                       where cat.CategoryName == CategoryName && prod.ProductName == ProductName
                       select prod).ToList();
            //{
            //    category = cat.CategoryName,
            //    product = prod.ProductName,
            //    product_id = prod.ProductId
            //};

            return Ok(abc);
        }
    }

    

}
