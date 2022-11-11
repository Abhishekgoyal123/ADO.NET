using Microsoft.AspNetCore.Mvc;
using Coditas.Ecomm.Repositories;
using Coditas.EComm.DataAccess;
using Coditas.EComm.DataAccess.Models;
using Coditas.EComm.Entities;
using MVC_1.CustomSessionExtensions;

namespace MVC_1.Controllers
{
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
            return View(category);
        }

        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            if (ModelState.IsValid)
            {
                var respose = await catRepo.CreateAsync(category);
                if (category.BasePrice < 0)
                    throw new Exception("Base Price Cannot be -ve");
                // Return to Index Action Method in Same
                // Controller
                return RedirectToAction("Index");
            }
            else
            {
                // Stay on Same View
                // THis will Show Error Messages
                return View(category);
            }
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
            HttpContext.Session.SetInt32("CategoryId", id);

            var category = await catRepo.GetAsync(id);
            HttpContext.Session.SetObject<Category>("Cat", category);
            return RedirectToAction("Index", "Product");
        }
    }
}
