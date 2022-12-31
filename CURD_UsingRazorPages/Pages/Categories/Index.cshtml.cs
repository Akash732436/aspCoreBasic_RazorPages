using CURD_UsingRazorPages.Data;
using CURD_UsingRazorPages.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace CURD_UsingRazorPages.Pages.Categories
{
    public class IndexModel : PageModel
    {
        ApplicationDbContext _db;

        public IEnumerable<Category> categories { get; set; }

        public IndexModel(ApplicationDbContext db)
        {
            _db = db;
        }
        public void OnGet()
        {
            categories = _db.Categories;
        }
    }
}
