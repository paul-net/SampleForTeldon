using Microsoft.Extensions.Configuration;

namespace AbcDesign.Business;

public class CatalogManager : ICatalogManager
{
	private string _dbstr;


	public CatalogManager(IConfiguration configuration)
	{
		_dbstr = configuration.GetConnectionString("MainDB")!;
	}

	/* useful for testing  */
	public CatalogManager(string dbstr)
	{
		_dbstr = dbstr;
	}


	public Entities.Catalog.Product? GetProduct(int productId)
	{
		var db = new DataLayer.CatalogDB(_dbstr);
		var et = db.GetProduct(productId);

		// ...

		return et;
	}

	public Models.PromotionModel GetPromoProducts()
	{
		var promo = new Models.PromotionModel();
		// ...
		return promo;
	}
}
