using Epr3.Models;

namespace Epr3.Services.ProductSave
{
    public interface IProductSaveService
    {
        Task ProductSaveAsync(CatalogProductModel product);
    }
}
