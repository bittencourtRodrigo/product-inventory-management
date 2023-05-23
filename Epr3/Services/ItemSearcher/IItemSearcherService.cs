using Epr3.Models;
namespace Epr3.Services.ItemSearcher
{
    public interface IItemSearcherService
    {
        Task<List<CatalogProductModel>> SearchProduct(string searchText);
    }
}