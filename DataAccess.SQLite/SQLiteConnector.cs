using SQLite;
using System;

namespace DataAccess.SQLite
{
    public static class SQLiteConnector
    {
        public enum DatabaseState
        {
            Empty,
            NotEmpty,
            Invalid
        };

        public static SQLiteConnection Connection { get; private set; }

        public static DatabaseState Connect(string databasePath)
        {
            try
            {
                Connection = new SQLiteConnection(databasePath, storeDateTimeAsTicks:false);

                return Connection.ExecuteScalar<int>(@"select count(*) from sqlite_master") == 0 ? DatabaseState.Empty : DatabaseState.NotEmpty;
            }
            catch (Exception)
            {
                Connection = null;
                return DatabaseState.Invalid;
            }
        }
    }
}