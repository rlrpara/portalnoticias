using PortalNoticias.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortalNoticias.Domain.Entities
{
    [Table("PERFIL_USUARIO")]
    public class PerfilUsuario : Entity
    {
        [Column(name: "NOME", Order = 2)]
        public string Nome { get; set; }
    }
}
