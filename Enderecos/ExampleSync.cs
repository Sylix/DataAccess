using DataAccess.SQLite;
using Enderecos.Models;

namespace Enderecos
{
    public static class ExampleSync
    {
        private const int DatabaseVersion = 1;

        public static void Execute()
        {
            var databaseState = SQLiteConnector.Connect(@"Cidades.sqlite3");

            switch (databaseState)
            {
                case SQLiteConnector.DatabaseState.Invalid:
                    return;
                case SQLiteConnector.DatabaseState.Empty:
                    DatabaseManager.CreateTables();
                    break;
            }

            if (DatabaseVersion > SQLiteConnector.Connection.ExecuteScalar<int>("SELECT Version FROM Config"))
            {
                DatabaseManager.UpdateTables();
            }

            ConsultasSimples();
            ConsultasCompletas();
        }

        private static void ConsultasSimples()
        {
            var endRep = new Repository<Endereco>();
            var munRep = new Repository<Municipio>();
            var ufRep = new Repository<UnidadeFederacao>();

            // Consulta sem repositório
            var sp1 = SQLiteConnector.Connection.Find<UnidadeFederacao>(e => e.Id == 35);
            // Consulta com repositório
            var sp2 = ufRep.Find(e => e.Id == 35);
            var sp3 = ufRep.Get(35);

            var endereco = endRep.Get(1);
            endereco.Municipio = munRep.Get(endereco.MunicipioID);
            endereco.Municipio.UF = ufRep.Get(endereco.Municipio.UnidadeFederacaoID);

            var estados = ufRep.Collection(e => e.Sigla.Contains("S"));
        }

        private static void ConsultasCompletas()
        {
            var endRep = new Repository<Endereco>();

            var enderecoRecursivo1 = endRep.GetWithChildren(1, recursive: true);
            var enderecoRecursivo2 = endRep.FindWithChildren(e => e.Id == 1, recursive: true);
        }
    }
}