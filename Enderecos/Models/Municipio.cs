using DataAccess.SQLite;
using SQLite;
using SQLiteNetExtensions.Attributes;

namespace Enderecos.Models
{
    public class Municipio : IEntityObject
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(50)]
        public string Nome { get; set; }
        [MaxLength(7)]
        public string CodigoIBGE { get; set; }
        [MaxLength(4)]
        public string CodigoSIAF { get; set; }

        [ForeignKey(typeof(UnidadeFederacao))]
        public int UnidadeFederacaoID { get; set; }

        [ManyToOne(CascadeOperations = CascadeOperation.CascadeRead)]
        public UnidadeFederacao UF { get; set; }
    }
}