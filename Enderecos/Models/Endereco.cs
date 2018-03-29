using DataAccess.SQLite;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Enderecos.Models
{
    public class Endereco : IEntityObject
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(10)]
        public string TipoLogradouro { get; set; }
        [MaxLength(40)]
        public string Logradouro { get; set; }
        [MaxLength(20)]
        public string Numero { get; set; }
        [MaxLength(40)]
        public string Complemento { get; set; }
        [MaxLength(50)]
        public string Bairro { get; set; }
        [MaxLength(9)]
        public string CEP { get; set; }

        [ForeignKey(typeof(Municipio))]
        public int MunicipioID { get; set; }

        [ManyToOne(CascadeOperations = CascadeOperation.CascadeRead)]
        public Municipio Municipio { get; set; }
    }
}