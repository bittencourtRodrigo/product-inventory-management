using Epr3.Models;
namespace Epr3.Services.CatalogClient
{
    public interface ICatalogClientService
    {
        Task<List<CatalogClientModel>> ClientGetAll();
    }
}
