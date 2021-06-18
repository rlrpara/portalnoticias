using PortalNoticias.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortalNoticias.Domain.Entities
{
    [Table("Categoria")]
    public class Categoria : Entity
    {
        [Column(name: "NOME", Order = 2)]
        public string Nome { get; set; }

        [Column(name: "ID_MUNICIPIO", Order = 3)]
        public string CodigoMunicipio { get; set; }
    }
}
