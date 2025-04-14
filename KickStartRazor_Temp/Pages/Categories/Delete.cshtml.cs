using KickStartRazor_Temp.Data;
using KickStartRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KickStartRazor_Temp.Pages.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public CategoryModel? Category { get; set; }

        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int? Id)
        {
            if (Id != null)
            {
                Category = _db.Categories.Find(Id);
            }

        }

        public IActionResult OnPost()
        {
            if (Category != null) { 
                _db.Categories.Remove(Category);
                _db.SaveChanges();
                TempData["success"] = "Category Removed Successfully";
                return RedirectToPage("Index");
            }
            return RedirectToPage("Index");

        }
    }
}
