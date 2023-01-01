using CURD_UsingRazorPages.Data;
using CURD_UsingRazorPages.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CURD_UsingRazorPages.Pages.Categories
{
    [BindProperties]
    public class DeleteModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public DeleteModel(ApplicationDbContext db)
        {
            _db = db;
        }

        public Category category { get; set; }

        public IActionResult OnGet(int? id)
        {
			if (id == 0 || id == null)
			{
				return NotFound();
			}
			category = _db.Categories.Find(id);
			if (category == null)
			{
				return NotFound();
			}
			return Page();
		}

        public IActionResult Onpost()
        {
            _db.Categories.Remove(category);
            _db.SaveChanges();
			TempData["success"] = "Category deleted successfully";
			return RedirectToPage("Index");
        }
    }
}
