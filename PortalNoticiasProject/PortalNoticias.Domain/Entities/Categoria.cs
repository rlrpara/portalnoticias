using System.ComponentModel.DataAnnotations.Schema;

namespace PortalNoticias.Domain.Entities
{
    [Table("Categoria")]
    public class Categoria
    {
        [Column("ID")]
        public int Codigo { get; set; }

        [Column("NOME")]
        public string Nome { get; set; }

        [Column("ID_MUNICIPIO")]
        public string CodigoMunicipio { get; set; }
    }
}
