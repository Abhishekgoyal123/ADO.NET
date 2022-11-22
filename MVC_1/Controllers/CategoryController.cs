using Microsoft.AspNetCore.Mvc;
using Coditas.Ecomm.Repositories;
using Coditas.EComm.DataAccess;
using Coditas.EComm.DataAccess.Models;
using Coditas.EComm.Entities;
using MVC_1.CustomSessionExtensions;
using Microsoft.AspNetCore.Authorization;

namespace MVC_1.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        IDbRepository<Category, int> catRepo;

        public CategoryController(IDbRepository<Category, int> catRepo)
        {
            this.catRepo = catRepo;
        }

        public async Task<IActionResult> Index()
        {
            var records = await catRepo.GetAsync();
            return View(records);
        }


        public async Task<IActionResult> Create()
        {
            var category = new Category();
            if (HttpContext.Session.GetObject<Category>("Session") != null)
            {
                category = HttpContext.Session.GetObject<Category>("Session");
                ViewBag.ErrorMessage = HttpContext.Session.GetString("ErrorMessage");
            }
            HttpContext.Session.Clear();
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category cat)
        {
            if (ModelState.IsValid)
            {
                if (cat.BasePrice < 0)
                {
                    HttpContext.Session.SetObject<Category>("Session", cat);
                    HttpContext.Session.SetString("ErrorMessage", "base price cannot be -ve");
                    throw new Exception("base price cannot be -ve");
                }
                var response = await catRepo.CreateAsync(cat);
                return RedirectToAction("Index");
            }
            else

                return View(cat);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, Category category)
        {
            var result = await catRepo.UpdateAsync(id, category);
            return RedirectToAction("Index");
        }

        //public async Task<IActionResult>Details(int id)
        //{
        //    var emp = catRepo.
        //}

        public async void Delete(int id)
        {
            var abc = await catRepo.DeleteAsync(id);


        }

        public async Task<IActionResult> ShowDetails(int id)
        {
            // HttpContext.Session.SetInt32("CategoryId", id);
            TempData["CategoryId"] = id;

            var category = await catRepo.GetAsync(id);
            HttpContext.Session.SetObject<Category>("Cat", category);
            return RedirectToAction("Index", "Product");
        }

        public async Task<IActionResult> IndexTagHelper()
        {
            try
            {
                var records = await catRepo.GetAsync();
                return View(records);

            }
            catch(Exception ex)
            {
                return View("Error");
            }

        }
    }
}

