using Epr3.Data;
using Epr3.Models;

namespace Epr3.Services.ProductSave
{
    public class ProductService : IProductService
    {
        private readonly SqliteDatabase _database;

        public ProductService(SqliteDatabase database)
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

        public async Task ProductDeleteAsync(CatalogProductModel product)
        {
            await _database.Database.DeleteAsync(product);
        }

        public async Task<List<CatalogProductModel>> ProductGetAllAsync()
        {
            await _database.Init();
            return await _database.Database.Table<CatalogProductModel>().ToListAsync();
        }

        public async Task ProductDownInventoryAsync(List<BasketProductModel> products)
        {
            await _database.Init();
            foreach (var product in products)
            {
                double newAmount = product.CurrentInventory - product.QuantityBasket;
                var oldProduct = await _database.Database.Table<CatalogProductModel>().FirstAsync(x => x.Id == product.Id);
                oldProduct.CurrentInventory = newAmount;
                await ProductSaveAsync(oldProduct);
            }
        }

        public async Task DefineUserIdAllProductsAsync(string uid)
        {
            await _database.Init();
            var products = await _database.Database.Table<CatalogProductModel>().ToListAsync();
            products.ForEach(x => x.Uid = uid);
            await _database.Database.UpdateAllAsync(products);
        }
    }
}