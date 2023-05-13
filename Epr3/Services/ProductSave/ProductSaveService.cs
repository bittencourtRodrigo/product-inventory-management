using Epr3.Data;
using Epr3.Models;

namespace Epr3.Services.ProductSave
{
    public class ProductSaveService : IProductSaveService
    {
        private readonly SqliteDatabase _database;

        public ProductSaveService(SqliteDatabase database)
        {
            _database = database;
        }

        public async Task ProductSaveAsync(CatalogProductModel product)
        {
            await _database.Init();

            if (product.Id == 0)
                await _database.Database.InsertAsync(product);
            else
                await _database.Database.UpdateAsync(product);
        }
    }
}