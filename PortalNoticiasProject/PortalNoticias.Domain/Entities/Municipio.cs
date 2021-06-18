using PortalNoticias.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortalNoticias.Domain.Entities
{
    [Table("Municipio")]
    public class Municipio : Entity
    {
        [Column(name: "NOME", Order = 2)]
        public string Nome { get; set; }
    }
}
