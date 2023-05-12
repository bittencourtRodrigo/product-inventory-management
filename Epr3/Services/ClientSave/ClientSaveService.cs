using Epr3.Data;
using Epr3.Models;

namespace Epr3.Services.ClientSave
{
    internal class ClientSaveService : IClientSaveService
    {
        private readonly SqliteDatabase _database;

        public async Task ClientSaveAsync(CatalogClientModel catalogClient)
        {
            await _database.ClientSaveAsync(catalogClient);
        }
    }
}
