using AbcDesign.Entities.Catalog;

namespace AbcDesign.Business
{
	public interface ICatalogManager
	{
		Product? GetProduct(int productId);
		Models.PromotionModel GetPromoProducts();
	}
}