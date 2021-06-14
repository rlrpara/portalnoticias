using System.ComponentModel.DataAnnotations.Schema;

namespace PortalNoticias.Domain.Entities
{
    [Table("Municipio")]
    public class Municipio
    {
        [Column("ID")]
        public int Codigo { get; set; }

        [Column("NOME")]
        public string Nome { get; set; }
    }
}
