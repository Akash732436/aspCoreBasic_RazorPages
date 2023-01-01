using CURD_UsingRazorPages.Data;
using CURD_UsingRazorPages.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CURD_UsingRazorPages.Pages.Categories
{
    [BindProperties]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _db;

        public CreateModel(ApplicationDbContext db)
        {
            _db= db;
        }
        public Category category { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            if (category.Name == category.DisplayOrder.ToString())
            {
                ModelState.AddModelError("Category.Name", "Name and Order number can not be same.");
            }

            if (ModelState.IsValid)
            {
				await _db.Categories.AddAsync(category);
				await _db.SaveChangesAsync();
                TempData["success"] = "Category created successfully";
				return RedirectToPage("Index");
			}
            TempData["error"] = "An error has occurred.";
            return Page();
        }

    }
}
