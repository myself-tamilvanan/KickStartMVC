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

        public IActionResult Create()
        {
            return View();
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
        
        public IActionResult Edit(int? Id)
        {
            if (Id == null && Id == 0)
            {
                return NotFound();
            }

            CategoryModel? category = _db.Categories.Find(Id);
            //CategoryModel? category1 = _db.Categories.FirstOrDefault(item => item.Id == Id);
            //CategoryModel? category2 = _db.Categories.Where(item => item.Id == Id).FirstOrDefault();

            if (category == null)
            {
                NotFound();
            }
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(CategoryModel category) {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(category);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(); 
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeletePost(int? Id) {
            if (Id == null && Id == 0)
            {
                return NotFound();
            }

            CategoryModel? category = _db.Categories.Find(Id);

            if (category == null)
            {
                NotFound();
            }
            else
            {
                _db.Categories.Remove(category);
                _db.SaveChanges();
                return RedirectToAction("Index", "Category");
            }

            return View(); 
        }
        
        public IActionResult Delete(int? Id)
        {
            if (Id == null && Id == 0)
            {
                return NotFound();
            }

            CategoryModel? category = _db.Categories.Find(Id);

            if (category == null)
            {
                NotFound();
            }

            return View(category);
        }
    }
}