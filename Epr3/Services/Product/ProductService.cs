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
            foreach (BasketProductModel product in products)
            {
                //double newAmount = product.CurrentInventory - product.QuantityBasket;
                CatalogProductModel oldProduct = await _database.Database.Table<CatalogProductModel>().FirstAsync(x => x.Id == product.Id);
                oldProduct.CurrentInventory -= product.QuantityBasket;
                await ProductSaveAsync(oldProduct);
            }
        }
        
        public async Task ProductSaveRangeAsync(List<CatalogProductModel> products)
        {
            await _database.Init();
            await _database.Database.DeleteAllAsync<CatalogProductModel>();
            await _database.Database.InsertAllAsync(products);
        }
    }
}