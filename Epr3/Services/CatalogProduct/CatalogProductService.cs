using Epr3.Data;
using Epr3.Models;

namespace Epr3.Services.CatalogProduct
{
    internal class CatalogProductService : ICatalogProductService
    {
        private readonly SqliteDatabase _database;

        public CatalogProductService(SqliteDatabase database)
        {
            _database = database;
        }
        public async Task<List<CatalogProductModel>> ProductGetAll()
        {
            await _database.Init();
            return await _database.Database.Table<CatalogProductModel>().ToListAsync();
        }
    }
}