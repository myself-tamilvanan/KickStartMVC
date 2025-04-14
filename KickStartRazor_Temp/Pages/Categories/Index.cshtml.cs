using KickStartRazor_Temp.Data;
using KickStartRazor_Temp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace KickStartRazor_Temp.Pages.Categories
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDbContext _db;
        public List<CategoryModel>? Categories { get; set; }

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            Categories = _db.Categories.ToList();
        }
    }
}
