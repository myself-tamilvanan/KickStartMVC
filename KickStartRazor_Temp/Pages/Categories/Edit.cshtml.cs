using KickStartRazor_Temp.Data;
using KickStartRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KickStartRazor_Temp.Pages.Categories
{
    [BindProperties]
    public class EditModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public CategoryModel? Category { get; set; }

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet(int? Id)
        {
            if(Id != null)
            {
                Category = _db.Categories.Find(Id);
            }
           
        }

        public IActionResult OnPost()
        {
            if (ModelState.IsValid)
            {
                _db.Categories.Update(Category);
                _db.SaveChanges();
                TempData["success"] = "Category Updated Successfully";
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
