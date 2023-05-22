using Epr3.Models;
using SQLite;

namespace Epr3.Data
{
    public class SqliteDatabase
    {
        public SQLiteAsyncConnection Database;

        public async Task Init()
        {
            if (Database != null)
                return;

            Database = new SQLiteAsyncConnection(SqliteConstants.DatabasePath, SqliteConstants.Flags);
            await Database.CreateTableAsync<CatalogProductModel>();
        }
    }
}