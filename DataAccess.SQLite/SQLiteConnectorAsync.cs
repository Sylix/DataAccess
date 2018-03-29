using SQLite;
using System;
using System.Threading.Tasks;

namespace DataAccess.SQLite
{
    public static class SQLiteConnectorAsync
    {
        public enum DatabaseState
        {
            Empty,
            NotEmpty,
            Invalid
        };

        public static SQLiteAsyncConnection Connection { get; private set; }

        public static async Task<DatabaseState> Connect(string databasePath)
        {
            try
            {
                Connection = new SQLiteAsyncConnection(databasePath, storeDateTimeAsTicks:false);

                int result = await Connection.ExecuteScalarAsync<int>(@"select count(*) from sqlite_master");

                return result == 0 ? DatabaseState.Empty : DatabaseState.NotEmpty;
            }
            catch (Exception)
            {
                Connection = null;
                return DatabaseState.Invalid;
            }
        }
    }
}