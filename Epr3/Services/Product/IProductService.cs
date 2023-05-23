using Epr3.Models;

namespace Epr3.Services.ProductSave
{
    public interface IProductService
    {
        Task ProductSaveAsync(CatalogProductModel product);
        Task ProductSaveRangeAsync(List<CatalogProductModel> product);
        Task ProductDeleteAsync(CatalogProductModel product);
        Task<List<CatalogProductModel>> ProductGetAllAsync();
        Task ProductDownInventoryAsync(List<BasketProductModel> products);
    }
}