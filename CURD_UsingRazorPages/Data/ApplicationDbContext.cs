using CURD_UsingRazorPages.Model;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel;

namespace CURD_UsingRazorPages.Data
{
	public class ApplicationDbContext:DbContext
	{

		public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)
		{}
		public DbSet<Category> Categories { get; set; }
	}
}
