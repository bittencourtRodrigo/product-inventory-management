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
            await Database.CreateTableAsync<Client>();
            await Database.CreateTableAsync<Provider>();
        }       
    }
}