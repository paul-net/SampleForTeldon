using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbcDesign.Entities.Catalog
{
	[Table("Category")]
	public class Category
	{
		[Key]
		[Required]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int CategoryId { get; set; }

		[Required]
		public string CategoryName { get; set; } = null!;

		public List<Product> Products { get; set; } = [];
	}
}
