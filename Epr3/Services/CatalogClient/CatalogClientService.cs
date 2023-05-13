using Epr3.Data;
using Epr3.Models;

namespace Epr3.Services.CatalogClient
{
    public class CatalogClientService : ICatalogClientService
    {
        private readonly SqliteDatabase _database;

        public CatalogClientService(SqliteDatabase database)
        {
            _database = database;
        }
        public async Task<List<CatalogClientModel>> ClientGetAll()
        {
            await _database.Init();
            return await _database.Database.Table<CatalogClientModel>().ToListAsync();
        }
    }
}
