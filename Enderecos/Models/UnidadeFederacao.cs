using DataAccess.SQLite;
using SQLite;

namespace Enderecos.Models
{
    public class UnidadeFederacao : IEntityObject
    {
        [PrimaryKey]
        public int Id { get; set; }
        [MaxLength(25)]
        public string Nome { get; set; }
        [MaxLength(2)]
        public string Sigla { get; set; }
    }
}