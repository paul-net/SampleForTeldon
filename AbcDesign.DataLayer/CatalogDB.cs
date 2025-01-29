using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AbcDesign.DataLayer;


/*
	Data access testing can be done independently on the data tier
*/
public class CatalogDB : BaseDb
{
	public CatalogDB(string dbstr) : base(dbstr)
	{
		
	}

	public Entities.Catalog.Product? GetProduct(int productId)
	{
		using (var db = new MainDbContext(_dbstr))
		{
			return db.Products
				.AsNoTracking()
				.Include(e => e.Category)
				.SingleOrDefault(p => p.ProductId == productId);
		}
	}


	/* with Dapper  */
	public Entities.Catalog.Category? GetCategoryWithProducts(int categoryId)
	{
		Entities.Catalog.Category? category = null!;

		string sql = "SomeStoredProcedure";

		var par = new { categoryId };

		using var cnn = new SqlConnection(_dbstr);

		using (var multi = cnn.QueryMultiple(sql, par, null, null, CommandType.StoredProcedure))
		{
			category = multi.ReadSingleOrDefault<Entities.Catalog.Category>();
			if (category != null)
			{
				category.Products = multi.Read<Entities.Catalog.Product>().ToList();
			}
		}

		return category;
	}
}
