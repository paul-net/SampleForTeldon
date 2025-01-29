using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbcDesign.Business.Models
{
	public class PromotionModel
	{
		public List<Entities.Catalog.Product> Products { get; set; } = [];
		public DateTime SaleEndDate { get; set; }
	}
}
