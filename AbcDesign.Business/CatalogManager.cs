using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace AbcDesign.Business;

public class CatalogManager : ICatalogManager
{
	private readonly string _dbstr;
	private readonly DataLayer.MainDbContext _dbContext;


	public CatalogManager(IConfiguration configuration, DataLayer.MainDbContext dbContext)
	{
		_dbstr = configuration.GetConnectionString("MainDB")!;
		_dbContext = dbContext;
	}


	public CatalogManager(string dbstr, DataLayer.MainDbContext dbContext)
	{
		_dbstr = dbstr;
		_dbContext = dbContext;
	}


	public Entities.Catalog.Product? GetProduct(int productId)
	{
		var et = _dbContext.Products
			.AsNoTracking()
			.Include(e => e.Category)			
			.SingleOrDefault(p => p.ProductId == productId);

		// if require some other logic.
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
