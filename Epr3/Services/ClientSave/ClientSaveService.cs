using Epr3.Data;
using Epr3.Models;

namespace Epr3.Services.ClientSave
{
    internal class ClientSaveService : IClientSaveService
    {
        private readonly SqliteDatabase _database;

        public ClientSaveService(SqliteDatabase database)
        {
            _database = database;
        }

        public async Task ClientSaveAsync(CatalogClientModel client)
        {
            await _database.Init();

            if (client.Id == 0)
                await _database.Database.InsertAsync(client);
            else
                await _database.Database.UpdateAsync(client);
        }
    }
}