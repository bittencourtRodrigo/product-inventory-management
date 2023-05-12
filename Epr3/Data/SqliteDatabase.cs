using Epr3.Models;
using SQLite;

namespace Epr3.Data
{
    public class SqliteDatabase
    {
        SQLiteAsyncConnection Database;

        async Task Init()
        {
            if (!(Database == null))
                return;

            Database = new SQLiteAsyncConnection(SqliteConstants.DatabasePath, SqliteConstants.Flags);
            await Database.CreateTableAsync<Product>();
            await Database.CreateTableAsync<CatalogClientModel>();
            await Database.CreateTableAsync<Provider>();
        }

        public async Task ClientSaveAsync(CatalogClientModel client)
        {
            await Init();
            await Database.InsertAsync(client);
        }
    }
}