using CURD_UsingRazorPages.Data;
using CURD_UsingRazorPages.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CURD_UsingRazorPages.Pages.Categories
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Category category { get; set; }

        private readonly ApplicationDbContext _db;

        public EditModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public IActionResult OnGet(int? id)
        {
            if(id==0 || id == null)
            {
                return NotFound();
            }
            category = _db.Categories.Find(id);
            if(category == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPost()
        {
            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("category.Name", "Name and display order can not be Same.");
            }
            if(ModelState.IsValid)
            {
               _db.Categories.Update(category);
               _db.SaveChanges();
				TempData["success"] = "Category updated successfully";
				return RedirectToPage("Index");
            }
            TempData["error"] = "An error has occurred.";
            return Page();
        }
    }
}
