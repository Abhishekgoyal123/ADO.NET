using Microsoft.AspNetCore.Mvc;
using Coditas.Ecomm.Repositories;
using Coditas.EComm.DataAccess;
using Coditas.EComm.DataAccess.Models;
using Coditas.EComm.Entities;

namespace MVC_1.Controllers
{
    public class CategoryController : Controller
    {
        IDbRepository<Category, int> catRepo;

        public CategoryController(IDbRepository<Category, int> catRepo)
        {
            this.catRepo = catRepo;
        }

        //public async Task<IActionResult> Index()
        //{
        //    var records = await catRepo.GetAsync();
        //    return View(records);
        //}
        

        [HttpPost]
        public async Task<IActionResult> Create(Category category)
        {
            var response = await catRepo.CreateAsync(category);
            return RedirectToAction("Index");
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
    }
}
