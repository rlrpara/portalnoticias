using PortalNoticias.Domain.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace PortalNoticias.Domain.Entities
{
    [Table("Usuario")]
    public class Usuario : Entity
    {
        [Column("NOME", Order = 2)]
        public string Nome { get; set; }

        [Column("EMAIL", Order = 3)]
        public string Email { get; set; }

        [Column("SENHA", Order = 4)]
        public string Senha { get; set; }

        [Column("ID_PERFIL", Order = 5)]
        public string CodigoPerfil { get; set; }
    }
}
