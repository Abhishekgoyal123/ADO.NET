using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using Coditas.Ecomm.Repositories;
using Coditas.EComm.DataAccess;
using Coditas.EComm.DataAccess.Models;
using Coditas.EComm.Entities;
using MVC_1.CustomSessionExtensions;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MVC_1.Controllers
{
    public class ProductController : Controller
    {
        IDbRepository<Product, int> prdRepo;
        IDbRepository<Category, int> catRepo;
        
        public ProductController(IDbRepository<Product, int> prdRepo, IDbRepository<Category, int> catRepo)
        {
            this.prdRepo = prdRepo;
            this.catRepo = catRepo;
        }
        public async Task<IActionResult> Index()
        {
            IEnumerable<Product> records = null;

            try
            {
                
                //if (TempData.Keys.Count > 0)
                //{
                    int CategoryId = Convert.ToInt32(TempData["CategoryId"]);


                    var cat = HttpContext.Session.GetObject<Category>("Cat");

                    if (CategoryId == 0)
                    {
                        records = await prdRepo.GetAsync();
                    }
                    else
                    {
                        records = (await prdRepo.GetAsync()).Where(p => p.SubCategoryId == CategoryId).ToList();
                    }
                //}


                TempData.Keep();

                return View(records);
            }
            catch (Exception ex)
            {
                return View("Error");
            }
        }

        public async Task<IActionResult> Create()
        {
            var x = TempData["CategoryId"];

            var product = new Product();
            // PAss LIst of Categories to Create.cshtml 
            List<Category> categories = (await catRepo.GetAsync()).ToList();

            List<SelectListItem> categoryItem = new List<SelectListItem>();
            
            foreach (var cat in categories)
            {
                categoryItem.Add(new SelectListItem(cat.CategoryName, cat.CategoryId.ToString()));
            }
            
            ViewBag.Categories = categoryItem;
            
            return View(product);
        }

        //[HttpPost]
        //public async Task<IActionResult> Create(Product product)
        //{

        //    if (ModelState.IsValid)
        //    {
        //        var respose = await prdRepo.CreateAsync(product);

        //        return RedirectToAction("Index");
        //    }
        //    else
        //    {
        //        // Stay on Same View
        //        // THis will Show Error Messages
        //        return View(product);
        //    }

        //}

        public async Task<IActionResult> Edit(int id)
        {
            var x = TempData["CategoryId"];
            var record = await prdRepo.GetAsync(id);
            return View(record);
        }

        //[HttpPost]
        //public async Task<IActionResult> Edit(int id, Product product)
        //{
        //    //try
        //    //{
        //        var result = await prdRepo.UpdateAsync(id, product);
        //        return RedirectToAction("Index");
        //    //}
        //    //catch (Exception ex)
        //    //{

        //    //    throw;
        //    //}
        //}

    }
}
