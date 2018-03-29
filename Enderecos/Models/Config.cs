using DataAccess.SQLite;
using SQLite;

namespace Enderecos.Models
{
    public class Config : IEntityObject
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public int Version { get; set; }
        public int NovoCampo { get; set; }
    }
}