using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace CURD_UsingRazorPages.Model
{
	public class Category
	{
		[Key]
		public int Id { get; set; }
		[Required]
		[DisplayName("Order Number")]
		public String Name { get; set; }
		[Range(1,100)]
		public int DisplayOrder { get; set; }

	}
}
