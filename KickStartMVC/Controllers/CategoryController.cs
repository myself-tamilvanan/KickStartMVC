using KickStartMVC.Data;
using KickStartMVC.Models;
using Microsoft.AspNetCore.Mvc;

namespace KickStartMVC.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ApplicationDbContext _db;
        public CategoryController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            List<CategoryModel> categories = _db.Categories.ToList();
            return View(categories);
        }

        [HttpPost]
        public IActionResult Create(CategoryModel category) {

            if(category.Name == category.DisplaOrder.ToString())
            {
                ModelState.AddModelError("Name", "Category Name and Display Order value cannot be equal");
            }

            if(category.Name != null && category.Name.ToLower() == "test")
            {
                ModelState.AddModelError("", "Invalid Category Name");
            }

            if (ModelState.IsValid)
            {
                _db.Categories.Add(category);
                _db.SaveChanges();
                return RedirectToAction("Index", "Category");
            }

            return View(); 
        }

    }
}