//using Coditas.EComm.Repositories;
//using Microsoft.AspNetCore.Mvc;
//using Coditas.EComm.Entities;
//using Coditas.Ecomm.Repositories;

//namespace MVC_Apps.Controllers
//{
//    public class CategoryProductController : Controller
//    {
//        IDbRepository<Category, int> catRepo;
//        IDbRepository<Product, int> prdRepo;
//        IDbRepository<SubCategory, int> subcaterepo;
//        public CategoryProductController(IDbRepository<Category, int> catRepo, IDbRepository<Product, int> prdRepo, IDbRepository<SubCategory, int> subcaterepo)
//        {
//            this.catRepo = catRepo;
//            this.prdRepo = prdRepo;
//            this.subcaterepo = subcaterepo;
//        }
//        public async Task<IActionResult> Index(int? id)
//        {
//            List<SubCategory> subcategories = null;
//            List<Product> products = null;
//            List<Category> categories = null;
//            Tuple<List<Category>, List<Product>> tuple = null;
//            categories = (await catRepo.GetAsync()).ToList();
//            if (id == null || id == 0)
//            {
//                products = (await prdRepo.GetAsync()).ToList();
//            }
//            else
//            {
//                var product = (await prdRepo.GetAsync()).ToList();
//                var category = (await catRepo.GetAsync()).ToList();
//                var subcategory = (await subcaterepo.GetAsync()).ToList();
//                products = (from pro in product
//                            join subcat in subcategory on pro.SubCategoryId equals subcat.SubCategoryId
//                            where subcat.CategoryId == id
//                            select pro).ToList();
//            }
//            tuple = new Tuple<List<Category>, List<Product>>(categories, products);
//            return View(tuple);
//        }
//        public IActionResult ShowDetails(int? id)
//        {
//            return RedirectToAction("Index", new { id = id });
//        }
//    }
//}

using Microsoft.AspNetCore.Mvc;
using Coditas.EComm.Entities;
using Coditas.EComm.Repositories;
using Coditas.Ecomm.Repositories;

namespace MVC_Apps.Controllers
{
    public class CategoryProductController : Controller
    {
        IDbRepository<Category, int> catRepo;
        IDbRepository<Product, int> prdRepo;
        public CategoryProductController(IDbRepository<Category, int> catRepo, IDbRepository<Product, int> prdRepo)
        {
            this.catRepo = catRepo;
            this.prdRepo = prdRepo;
        }

        public async Task<IActionResult> Index(int? id)
        {
            List<Category> categories = null;
            List<Product> products = null;
            Tuple<List<Category>, List<Product>> tuple = null;

            categories = (await catRepo.GetAsync()).ToList();

            if (id == null || id == 0)
            {
                products = (await prdRepo.GetAsync()).ToList();
            }
            else
            {
                products = (await prdRepo.GetAsync()).Where(p => p.SubCategoryId == id).ToList();
            }

            tuple = new Tuple<List<Category>, List<Product>>(categories, products);

            return View(tuple);
        }

        public IActionResult ShowDetails(int? id)
        {
            return RedirectToAction("Index", new { id = id });
        }
    }
}