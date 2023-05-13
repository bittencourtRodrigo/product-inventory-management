using Epr3.Models;

namespace Epr3.Services.CatalogProduct
{
    public interface ICatalogProductService
    {
        Task<List<CatalogProductModel>> ProductGetAll();
    }
}
