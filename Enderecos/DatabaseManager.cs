using DataAccess.SQLite;
using Enderecos.Models;

namespace Enderecos
{
    public static class DatabaseManager
    {
        public static void CreateTables()
        {
            SQLiteConnector.Connection.CreateTable<Config>();
            SQLiteConnector.Connection.CreateTable<UnidadeFederacao>();
            SQLiteConnector.Connection.CreateTable<Municipio>();
            SQLiteConnector.Connection.CreateTable<Endereco>();

            SQLiteConnector.Connection.Insert(new Config
            {
                Version = 1
            });

            InsereUFs();
            InsereMunicipios();
            InsereEnderecos();
        }

        public static void UpdateTables()
        {

        }

        private static void InsereUFs()
        {
            var repUF = new Repository<UnidadeFederacao>();

            var uf = new UnidadeFederacao
            {
                Id = 11,
                Nome = "Rondônia",
                Sigla = "RO"
            };
            repUF.Insert(uf);

            uf = new UnidadeFederacao
            {
                Id = 12,
                Nome = "Acre",
                Sigla = "AC"
            };
            repUF.Insert(uf);

            uf = new UnidadeFederacao
            {
                Id = 13,
                Nome = "Amazonas",
                Sigla = "AM"
            };
            repUF.Insert(uf);

            uf = new UnidadeFederacao
            {
                Id = 14,
                Nome = "Roraima",
                Sigla = "RR"
            };
            repUF.Insert(uf);

            uf = new UnidadeFederacao
            {
                Id = 15,
                Nome = "Pará",
                Sigla = "PA"
            };
            repUF.Insert(uf);

            uf = new UnidadeFederacao
            {
                Id = 16,
                Nome = "Amapá",
                Sigla = "AP"
            };
            repUF.Insert(uf);

            uf = new UnidadeFederacao
            {
                Id = 17,
                Nome = "Tocantins",
                Sigla = "TO"
            };
            repUF.Insert(uf);

            uf = new UnidadeFederacao
            {
                Id = 21,
                Nome = "Maranhão",
                Sigla = "MA"
            };
            repUF.Insert(uf);

            uf = new UnidadeFederacao
            {
                Id = 22,
                Nome = "Piauí",
                Sigla = "PI"
            };
            repUF.Insert(uf);

            uf = new UnidadeFederacao
            {
                Id = 23,
                Nome = "Ceará",
                Sigla = "CE"
            };
            repUF.Insert(uf);

            uf = new UnidadeFederacao
            {
                Id = 24,
                Nome = "Rio Grande do Norte",
                Sigla = "RN"
            };
            repUF.Insert(uf);

            uf = new UnidadeFederacao
            {
                Id = 25,
                Nome = "Paraíba",
                Sigla = "PB"
            };
            repUF.Insert(uf);

            uf = new UnidadeFederacao
            {
                Id = 26,
                Nome = "Pernambuco",
                Sigla = "PE"
            };
            repUF.Insert(uf);

            uf = new UnidadeFederacao
            {
                Id = 27,
                Nome = "Alagoas",
                Sigla = "AL"
            };
            repUF.Insert(uf);

            uf = new UnidadeFederacao
            {
                Id = 28,
                Nome = "Sergipe",
                Sigla = "SE"
            };
            repUF.Insert(uf);

            uf = new UnidadeFederacao
            {
                Id = 29,
                Nome = "Bahia",
                Sigla = "BA"
            };
            repUF.Insert(uf);

            uf = new UnidadeFederacao
            {
                Id = 31,
                Nome = "Minas Gerais",
                Sigla = "MG"
            };
            repUF.Insert(uf);

            uf = new UnidadeFederacao
            {
                Id = 32,
                Nome = "Espírito Santo",
                Sigla = "ES"
            };
            repUF.Insert(uf);

            uf = new UnidadeFederacao
            {
                Id = 33,
                Nome = "Rio de Janeiro",
                Sigla = "RJ"
            };
            repUF.Insert(uf);

            uf = new UnidadeFederacao
            {
                Id = 35,
                Nome = "São Paulo",
                Sigla = "SP"
            };
            repUF.Insert(uf);

            uf = new UnidadeFederacao
            {
                Id = 41,
                Nome = "Paraná",
                Sigla = "PR"
            };
            repUF.Insert(uf);

            uf = new UnidadeFederacao
            {
                Id = 42,
                Nome = "Santa Catarina",
                Sigla = "SC"
            };
            repUF.Insert(uf);

            uf = new UnidadeFederacao
            {
                Id = 43,
                Nome = "Rio Grande do Sul",
                Sigla = "RS"
            };
            repUF.Insert(uf);

            uf = new UnidadeFederacao
            {
                Id = 50,
                Nome = "Mato Grosso do Sul",
                Sigla = "MS"
            };
            repUF.Insert(uf);

            uf = new UnidadeFederacao
            {
                Id = 51,
                Nome = "Mato Grosso",
                Sigla = "MT"
            };
            repUF.Insert(uf);


            uf = new UnidadeFederacao
            {
                Id = 52,
                Nome = "Goiás",
                Sigla = "GO"
            };
            repUF.Insert(uf);


            uf = new UnidadeFederacao
            {
                Id = 53,
                Nome = "Distrito Federal",
                Sigla = "DF"
            };
            repUF.Insert(uf);
        }

        private static void InsereMunicipios()
        {
            var repMun = new Repository<Municipio>();

            var mun = new Municipio
            {
                Nome = "São Paulo",
                UnidadeFederacaoID = 35
            };
            repMun.Insert(mun);

            mun = new Municipio
            {
                Nome = "Florianópolis",
                UnidadeFederacaoID = 42
            };
            repMun.Insert(mun);

            mun = new Municipio
            {
                Nome = "Brasília",
                UnidadeFederacaoID = 53
            };
            repMun.Insert(mun);
        }

        private static void InsereEnderecos()
        {
            var repEnd = new Repository<Endereco>();

            var end = new Endereco
            {
                TipoLogradouro = "Rua",
                Logradouro = "Líbero Badaró",
                Numero = "425",
                Complemento = "Edifício Grande São Paulo",
                Bairro = "Centro",
                MunicipioID = 1,
                CEP = "01009-905"
            };

            repEnd.Insert(end);
        }
    }
}