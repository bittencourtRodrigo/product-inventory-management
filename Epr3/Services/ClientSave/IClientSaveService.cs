using Epr3.Models;

namespace Epr3.Services.ClientSave
{
    public interface IClientSaveService
    {
        public Task ClientSaveAsync(CatalogClientModel catalogClient);
    }
}
