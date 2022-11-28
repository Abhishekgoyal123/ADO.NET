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

        public Search(eShoppingCodiContext _context)
        {
            this.context = _context;
        }
        [HttpGet]
        public IActionResult abcd(string CategoryName, string ProductName)
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

        [HttpGet("/SearchAssignment")]

        public IActionResult SearchAssignment(string abc)
        {
            string ram;
           
            string[] ramArray = null;
            //string[] manufacturerNameArray = null;
            //string number = "123456789 ";
            IQueryable<Product> result = null;
            if (!abc.Contains(" "))
            {

            }
            else
            {
               // if(abc.Contains(number))
                string[] test = abc.Split(" ");
                //string [] q = test[1].Split("");
                for(int i = 0; i < test.Length; i++)
                {
                    if (test[i].Contains("GB"))
                    {
                       ramArray = test[i].Split("GB");
                    }
                }
                
                result = from prod in context.Products
                             join manufacture in context.Manufacturers on prod.ManufacturerId equals manufacture.ManufacturerId
                             where (prod.ProductName == test[0] && prod.Descrition.Contains(ramArray[1])) || (prod.ProductName == test[0] && manufacture.ManufacturerName == test[1]) 

                             select prod;

            }


            return Ok(result);             
        }

        [HttpGet("/search1")]
        public IActionResult Search1(string abc)
        {
            IQueryable<Product> result = null;
           // Product p = new Product();
            List<Product> resultList = new List<Product>();
            
            string[] arr = abc.Split(" ");

            result = from prod in context.Products
                     join manufacture in context.Manufacturers on prod.ManufacturerId equals manufacture.ManufacturerId
                     select prod;
                     
            
            for (int i = 0; i < arr.Length; i++)
            {
                
                foreach (var item in result)
                {
                    
                    if (item.ProductName.Contains(arr[i]) || item.Descrition.Contains(abc[i]))
                    {
                        resultList.Add(item);
                        
                    }
                }

            }
            
            //resultList.Sort( m => m.ProductName=="");
           
            return Ok(resultList.Distinct());
           // return Ok(result);       
        }

    }

}
