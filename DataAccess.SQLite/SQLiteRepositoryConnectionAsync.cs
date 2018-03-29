using SQLite;

namespace DataAccess.SQLite
{
    // Essa classe foi criada para compartilhar uma conexão estática entre todos os repositórios.
    // Atributos estáticos de uma class de <T>, somente compartilham atributos estáticos nas classes de mesmo tipo <T>.
    public class SQLiteRepositoryConnectionAsync
    {
        protected static readonly SQLiteAsyncConnection Conn = SQLiteConnectorAsync.Connection;
    }
}