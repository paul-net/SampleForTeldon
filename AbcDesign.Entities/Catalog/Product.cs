using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace AbcDesign.Entities.Catalog
{
	[Table("Product")]
	public class Product
	{
		[Key]
		[Required]
		[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
		public int ProductId { get; set; }

		[Required]
		public string Sku { get; set; } = null!;

		/* use [Column("name")] if name of column is different in db */
		[Required]
		public string ProductName { get; set; } = null!;

		[Required]
		public int CategoryId { get; set; }


		public Category Category { get; set; } = null!;
	}
}
