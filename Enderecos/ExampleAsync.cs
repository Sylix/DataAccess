using System.Threading.Tasks;
using DataAccess.SQLite;
using Enderecos.Models;

namespace Enderecos
{
    public static class ExampleAsync
    {
        private const int DatabaseVersion = 1;

        public static async Task Execute()
        {
            var databaseState = await SQLiteConnectorAsync.Connect(@"Cidades.sqlite3");

            switch (databaseState)
            {
                case SQLiteConnectorAsync.DatabaseState.Invalid:
                    return;
                case SQLiteConnectorAsync.DatabaseState.Empty:
                    DatabaseManager.CreateTables();
                    break;
            }

            if (DatabaseVersion > await SQLiteConnectorAsync.Connection.ExecuteScalarAsync<int>("SELECT Version FROM Config"))
            {
                DatabaseManager.UpdateTables();
            }

            await ConsultasSimples();
            await ConsultasCompletas();
        }

        private static async Task ConsultasSimples()
        {
            var endRep = new RepositoryAsync<Endereco>();
            var munRep = new RepositoryAsync<Municipio>();
            var ufRep = new RepositoryAsync<UnidadeFederacao>();

            // Consulta sem repositório
            var sp1 = await SQLiteConnectorAsync.Connection.FindAsync<UnidadeFederacao>(e => e.Id == 35);
            // Consulta com repositório
            var sp2 = await ufRep.FindAsync(e => e.Id == 35);
            var sp3 = await ufRep.GetAsync(35);

            var endereco = await endRep.GetAsync(1);
            endereco.Municipio = await munRep.GetAsync(endereco.MunicipioID);
            endereco.Municipio.UF = await ufRep.GetAsync(endereco.Municipio.UnidadeFederacaoID);

            var estados = await ufRep.CollectionAsync(e => e.Sigla.Contains("S"));
        }

        private static async Task ConsultasCompletas()
        {
            var endRep = new RepositoryAsync<Endereco>();

            var enderecoRecursivo1 = await endRep.GetWithChildrenAsync(1, recursive: true);
            var enderecoRecursivo2 = await endRep.FindWithChildrenAsync(e => e.Id == 1, recursive: true);
        }
    }
}