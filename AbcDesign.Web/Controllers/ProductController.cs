using AbcDesign.Business;
using Microsoft.AspNetCore.Mvc;

namespace AbcDesign.Web.Controllers;

[Route("product")]
public class ProductController : Controller
{
	/*
		controller makes all call through the Business layer for data access 
	*/

	private readonly ICatalogManager _catalogManager;

	public ProductController(ICatalogManager catalogManager)
	{
		_catalogManager = catalogManager;
	}


	[Route("getdetail/{id:int}")]
	public IActionResult GetDetail(int id)
	{
		var vmodel = new Models.ProductDetailModel();
		vmodel.Product = _catalogManager.GetProduct(id);	

		if (vmodel.Product == null)
		{
			// for simplicity in sample
			return NotFound();
		}

		return View("Detail", vmodel);
	}
}
